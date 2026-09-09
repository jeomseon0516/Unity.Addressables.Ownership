using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Jeomseon.Unity.Addressables.Ownership.Tests
{
    internal partial class ManagedAddressablesOwner : MonoBehaviour
    {
        [ManagedAsset] private TextAsset _asset;
        [ManagedAsset] private GameObject _instance;
        [ManagedAssetCollection] private IReadOnlyList<TextAsset> _assets;
    }

    public sealed class ManagedAssetLifetimeTests
    {
        private const string PrefabKey = "jeomseon-addressables-sample-prefab";
        private const string MessageKey = "jeomseon-addressables-sample-message";

        [UnityTest]
        public IEnumerator RetainAndTake_CreateIndependentAssetOwnership()
        {
            async Awaitable Run()
            {
                using var service = new Jeomseon.Unity.Addressables.AddressablesService();
                var ownerObject = new GameObject("Owner");
                var owner = ownerObject.AddComponent<ManagedAddressablesOwner>();
                owner.SetAsset(await service.LoadAssetAsync<TextAsset>(MessageKey));

                var retained = owner.RetainAsset();
                var transferred = owner.TakeAsset();
                UnityEngine.Object.Destroy(ownerObject);
                await Awaitable.NextFrameAsync();

                Assert.That(retained.IsValid, Is.True);
                Assert.That(transferred.IsValid, Is.True);
                Assert.That(service.ActiveResourceCount, Is.EqualTo(2));
                retained.Dispose();
                transferred.Dispose();
                Assert.That(service.ActiveResourceCount, Is.Zero);
            }

            return Run();
        }

        [UnityTest]
        public IEnumerator CollectionRetainAndTake_CreateIndependentOwnership()
        {
            async Awaitable Run()
            {
                using var service = new Jeomseon.Unity.Addressables.AddressablesService();
                var ownerObject = new GameObject("Owner");
                var owner = ownerObject.AddComponent<ManagedAddressablesOwner>();
                owner.SetAssets(await service.LoadAssetsAsync<TextAsset>(MessageKey));

                var retained = owner.RetainAssets();
                var transferred = owner.TakeAssets();
                UnityEngine.Object.Destroy(ownerObject);
                await Awaitable.NextFrameAsync();

                Assert.That(retained.IsValid, Is.True);
                Assert.That(transferred.IsValid, Is.True);
                Assert.That(service.ActiveResourceCount, Is.EqualTo(2));
                retained.Dispose();
                transferred.Dispose();
                Assert.That(service.ActiveResourceCount, Is.Zero);
            }

            return Run();
        }

        [UnityTest]
        public IEnumerator WrongTake_DoesNotDetachInstanceOwnership()
        {
            async Awaitable Run()
            {
                using var service = new Jeomseon.Unity.Addressables.AddressablesService();
                var ownerObject = new GameObject("Owner");
                var owner = ownerObject.AddComponent<ManagedAddressablesOwner>();
                var handle = await service.InstantiateAsync(PrefabKey);
                owner.SetInstance(handle);

                Assert.Throws<InvalidOperationException>(() => owner.TakeInstanceAssetLease());
                Assert.That(handle.IsValid, Is.True);
                UnityEngine.Object.Destroy(ownerObject);
                await Awaitable.NextFrameAsync();

                Assert.That(handle.IsValid, Is.False);
                Assert.That(service.ActiveResourceCount, Is.Zero);
            }

            return Run();
        }

        [UnityTest]
        public IEnumerator TakeInstance_TransfersWithoutOwnerRelease()
        {
            async Awaitable Run()
            {
                using var service = new Jeomseon.Unity.Addressables.AddressablesService();
                var ownerObject = new GameObject("Owner");
                var owner = ownerObject.AddComponent<ManagedAddressablesOwner>();
                owner.SetInstance(await service.InstantiateAsync(PrefabKey));

                var transferred = owner.TakeInstanceInstanceHandle();
                UnityEngine.Object.Destroy(ownerObject);
                await Awaitable.NextFrameAsync();

                Assert.That(transferred.IsValid, Is.True);
                transferred.Dispose();
                Assert.That(service.ActiveResourceCount, Is.Zero);
            }

            return Run();
        }
    }
}
