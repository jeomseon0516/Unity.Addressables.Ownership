# Jeomseon Unity Addressables Ownership

Mark a raw asset field with `[ManagedAsset]`. The source generator stores the existing `AddressableAssetLease<T>`
or `AddressableInstanceHandle` directly in a hidden field; it does not create an ownership wrapper. Pass the result
of the base Addressables load API to the generated setter. Replacement, `Clear{Name}()`, and owner destruction
release the Addressables operation automatically.

The generated value property is borrowed. Do not keep that asset or GameObject beyond its owner unless ownership
is transferred explicitly.
Use generated `Retain{Name}()` to create an independent asset lease, or `Take{Name}()` to transfer the current
lease. GameObject fields expose separate asset-lease and instance-handle take methods.
For collections, declare `[ManagedAssetCollection] IReadOnlyList<T>`. Generated set, clear, retain, and take
methods store the existing `AddressableAssetCollectionLease<T>` directly.
