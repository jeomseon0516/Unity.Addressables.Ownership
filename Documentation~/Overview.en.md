# Jeomseon Unity Addressables Ownership

[한국어](Overview.md) · [Installation](../README.en.md)

## Purpose

Binds existing Addressables handles to the owner GameObject lifetime through ManagedAsset and ManagedAssetCollection.

## Usage flow

Annotate a raw asset field in a partial Component and pass load results to generated Set. Replacement/Clear/destruction release automatically; Take transfers without release and Retain creates an independent Lease.

## Contracts and limitations

Generated getters return borrowed values. Direct field assignment bypasses tracking. Transfer/retain before longer storage; retained Leases still follow the original Service lifetime.

## Package requirements

- Package ID: `com.jeomseon.unity.addressables.ownership`
- Version: `0.1.1`
- Unity: `6000.6` / `0f1`
- `com.jeomseon.unity.addressables`: `0.4.0`
- `com.jeomseon.unity.ownership`: `0.1.0`

## Samples and verification

Import the following from Package Manager > Samples. Open the included Scene or Editor tool; follow any Setup step in its sample README.

- [Basic Usage](../Samples~/BasicUsage/README.md)
  - [AddressablesOwnershipBasicUsage](../Samples~/BasicUsage/AddressablesOwnershipBasicUsage.unity)

[Test sources](../Tests)

Add the package ID to manifest `testables`, then run the relevant Unity Test Runner assemblies. These links describe available tests, not a new successful test run.

## Source map

- [ManagedAssetAttribute](../Runtime/ManagedAssetAttribute.cs)
- [ManagedAssetCollectionAttribute](../Runtime/ManagedAssetCollectionAttribute.cs)
