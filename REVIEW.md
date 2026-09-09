# Review guide

- Addressables의 기존 lease/instance handle 수명과 공용 ownership handle이 1:1로 대응하는지 확인합니다.
- 교체·취소·owner 파괴에서 operation이 중복 release되지 않는지 확인합니다.
- 전역 asset registry나 별도 reference count를 추가하지 않습니다.
- `[ManagedAssetCollection]`은 `IReadOnlyList<T>` 필드에만 허용하며 기존
  `AddressableAssetCollectionLease<T>`를 직접 보관하는지 확인합니다.
- collection의 retain과 take가 서로 독립적인 lease를 유지하고 owner 파괴 시 이중 release되지 않는지
  확인합니다.
