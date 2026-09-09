# Jeomseon Unity Addressables Ownership

원본 에셋 필드에 `[ManagedAsset]`을 붙이면 Source Generator가 기존 `AddressableAssetLease<T>` 또는
`AddressableInstanceHandle`을 숨은 필드에 직접 보관합니다. 별도의 ownership Wrapper는 없습니다.

```csharp
public partial class CharacterView : MonoBehaviour
{
    [ManagedAsset] private Sprite _portrait;

    public async Awaitable LoadAsync(AddressablesService service, AssetReferenceSprite reference)
        => SetPortrait(await service.LoadAssetReferenceAsync<Sprite>(reference));
}
```

교체, `ClearPortrait()`, owner GameObject 파괴 시 생성 코드가 Addressables 작업을 자동 해제합니다.
`Portrait` getter가 반환하는 값은 owner 수명 동안만 유효한 borrowed reference입니다.
더 오래 보관하려면 `RetainPortrait()`으로 독립 Lease를 만들고, 소유권 자체를 이동하려면
`TakePortrait()`을 사용합니다. GameObject 필드는 asset lease와 instance handle을 구분하기 위해
`Take{Name}AssetLease()`와 `Take{Name}InstanceHandle()`을 생성합니다.

여러 에셋은 원본 읽기 전용 목록 필드로 선언합니다. 생성 코드는 기존
`AddressableAssetCollectionLease<T>`를 직접 보관합니다.

```csharp
[ManagedAssetCollection] private IReadOnlyList<Sprite> _portraits;
```

이 필드에는 `SetPortraits`, `ClearPortraits`, `RetainPortraits`, `TakePortraits`가 생성됩니다.
