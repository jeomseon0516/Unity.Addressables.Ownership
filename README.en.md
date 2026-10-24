# Jeomseon Unity Addressables Ownership

[한국어](README.md) | English

Binds existing Addressables handles to the owner GameObject lifetime through ManagedAsset and ManagedAssetCollection.

## Quick start

Annotate a raw asset field in a partial Component and pass load results to generated Set. Replacement/Clear/destruction release automatically; Take transfers without release and Retain creates an independent Lease.

## Contracts and limitations

Generated getters return borrowed values. Direct field assignment bypasses tracking. Transfer/retain before longer storage; retained Leases still follow the original Service lifetime.

## Requirements

- Unity `6000.6.0f1`
- Package: `com.jeomseon.unity.addressables.ownership` `0.1.1`
- `com.jeomseon.unity.addressables`: `0.4.0`
- `com.jeomseon.unity.ownership`: `0.1.0`

## Installation

Merge this into your project's `Packages/manifest.json`; preserve existing dependencies and registries.

```json
{
  "scopedRegistries": [
    {
      "name": "OpenUPM",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.jeomseon"
      ]
    }
  ],
  "dependencies": {
    "com.jeomseon.unity.addressables.ownership": "0.1.1"
  }
}
```

Or use **Install package from git URL** in Package Manager:

```text
https://github.com/jeomseon0516/Unity.Addressables.Ownership.git#v0.1.1
```

## Samples

Import the desired entry from **Package Manager > Samples**. Use the included Scene/Editor tool and complete its Setup step first, if required.

- [Basic Usage](Samples~/BasicUsage/README.md)
  - [AddressablesOwnershipBasicUsage](Samples~/BasicUsage/AddressablesOwnershipBasicUsage.unity)

## Tests

[Test sources](Tests)

Add the package ID to manifest `testables`, then execute its relevant EditMode/PlayMode assemblies in Unity Test Runner.

## Further reading

[Complete source map and package metadata](Documentation~/Overview.en.md)
- [Changelog](CHANGELOG.md)

## License

[License](LICENSE.md)
