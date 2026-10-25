# Jeomseon Unity Addressables Ownership

한국어 | [English](README.en.md)

ManagedAsset·ManagedAssetCollection로 기존 Addressables handle을 owner GameObject 수명에 연결합니다.

## 빠르게 시작하기

partial Component의 원본 asset 필드에 Attribute 선언 → 생성 Set 메서드에 로드 결과 전달 → 교체/Clear/owner 파괴 시 자동 해제. Take는 해제 없이 양도하고 Retain은 독립 Lease를 만듭니다.

## 계약과 주의사항

생성 getter는 borrowed 값입니다. Managed 필드를 직접 대입하면 handle 등록을 우회합니다. owner보다 오래 보관할 때는 handle을 양도/retain하고, retained Lease도 원래 Service의 수명을 따릅니다.

## 요구 사항

- Unity `6000.6.0f1`
- 패키지: `com.jeomseon.unity.addressables.ownership` `0.1.1`
- `com.jeomseon.unity.addressables`: `0.4.0`
- `com.jeomseon.unity.ownership`: `0.1.0`

## 설치

프로젝트 `Packages/manifest.json`의 기존 dependencies와 registry를 유지하면서 다음 항목을 병합합니다.

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

또는 Package Manager의 **Install package from git URL**을 사용합니다:

```text
https://github.com/jeomseon0516/Unity.Addressables.Ownership.git#v0.1.1
```

## API 사용과 상세 설명

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

## 샘플 실행

**Package Manager > Samples**에서 예제를 Import합니다. 포함된 Scene 또는 Editor 도구를 열고 필요한 Setup 메뉴를 먼저 실행합니다.

- [Basic Usage](Samples~/BasicUsage/README.md)
  - [AddressablesOwnershipBasicUsage](Samples~/BasicUsage/AddressablesOwnershipBasicUsage.unity)

## 테스트

[테스트 코드](Tests)

manifest의 `testables`에 패키지 ID를 추가하고 Unity Test Runner의 관련 EditMode/PlayMode 어셈블리를 실행합니다.

## 추가 문서

[전체 코드 지도와 패키지 구성](Documentation~/Overview.md)
- [Changelog](CHANGELOG.md)

## 라이선스

[License](LICENSE.md)
