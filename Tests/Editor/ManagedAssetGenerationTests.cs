using NUnit.Framework;
using UnityEngine;

namespace Jeomseon.Unity.Addressables.Ownership.Tests
{
    internal partial class ManagedAssetOwner : MonoBehaviour
    {
        [ManagedAsset] private TextAsset _asset;
        [ManagedAsset] private GameObject _instance;
    }

    public sealed class ManagedAssetGenerationTests
    {
        [Test]
        public void RawAssetFields_GenerateBorrowedValuesAndClearMethods()
        {
            var ownerObject = new GameObject("Managed asset owner");
            var owner = ownerObject.AddComponent<ManagedAssetOwner>();

            Assert.That(owner.Asset, Is.Null);
            Assert.That(owner.Instance, Is.Null);

            owner.ClearAsset();
            owner.ClearInstance();
            Assert.That(owner.TakeAsset(), Is.Null);
            Assert.That(owner.TakeInstanceAssetLease(), Is.Null);
            Assert.That(owner.TakeInstanceInstanceHandle(), Is.Null);
            Assert.Throws<System.InvalidOperationException>(() => owner.RetainAsset());

            Object.DestroyImmediate(ownerObject);
        }
    }
}
