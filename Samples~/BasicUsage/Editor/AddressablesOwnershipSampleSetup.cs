using System;
using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace Jeomseon.Unity.Addressables.Ownership.Samples.BasicUsage.Editor
{
    internal static class AddressablesOwnershipSampleSetup
    {
        private const string GroupName = "Jeomseon Addressables Ownership Basic Usage";
        private const string MessageKey = "jeomseon-addressables-ownership-message";

        [MenuItem("Jeomseon/Addressables Ownership/Setup Basic Usage Sample")]
        private static void Setup()
        {
            var settings = AddressableAssetSettingsDefaultObject.GetSettings(true);
            var group = settings.FindGroup(GroupName) ?? settings.CreateGroup(
                GroupName, false, false, true, null,
                typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            var guid = AssetDatabase.FindAssets("OwnershipSampleMessage t:TextAsset")
                .FirstOrDefault(candidate => AssetDatabase.GUIDToAssetPath(candidate)
                    .IndexOf("Addressables Ownership", StringComparison.OrdinalIgnoreCase) >= 0);
            if (string.IsNullOrEmpty(guid)) throw new InvalidOperationException("Ownership sample message not found.");
            var entry = settings.CreateOrMoveEntry(guid, group);
            entry.address = MessageKey;
            settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryModified, entry, true, true);
            AssetDatabase.SaveAssets();
            Debug.Log("[PASS] Addressables Ownership sample is configured.");
        }
    }
}
