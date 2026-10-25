# Jeomseon Unity Addressables Ownership

[English](Overview.en.md) · [설치](../README.md)

## 목적

ManagedAsset·ManagedAssetCollection로 기존 Addressables handle을 owner GameObject 수명에 연결합니다.

## 사용 흐름

partial Component의 원본 asset 필드에 Attribute 선언 → 생성 Set 메서드에 로드 결과 전달 → 교체/Clear/owner 파괴 시 자동 해제. Take는 해제 없이 양도하고 Retain은 독립 Lease를 만듭니다.

## 계약과 제한

생성 getter는 borrowed 값입니다. Managed 필드를 직접 대입하면 handle 등록을 우회합니다. owner보다 오래 보관할 때는 handle을 양도/retain하고, retained Lease도 원래 Service의 수명을 따릅니다.

## 패키지 요구 사항

- Package ID: `com.jeomseon.unity.addressables.ownership`
- Version: `0.1.1`
- Unity: `6000.6` / `0f1`
- `com.jeomseon.unity.addressables`: `0.4.0`
- `com.jeomseon.unity.ownership`: `0.1.0`

## 샘플과 검증

Package Manager > Samples에서 다음 예제를 Import하세요. 포함된 Scene 또는 Editor 도구를 열고 샘플 README의 Setup 절차를 먼저 수행합니다.

- [Basic Usage](../Samples~/BasicUsage/README.md)
  - [AddressablesOwnershipBasicUsage](../Samples~/BasicUsage/AddressablesOwnershipBasicUsage.unity)

[테스트 코드](../Tests)

소비 프로젝트 manifest의 `testables`에 패키지 ID를 추가하고 Unity Test Runner의 관련 어셈블리를 실행합니다. 위 링크는 테스트 위치이며 이번 문서 수정으로 새 테스트 실행을 주장하지 않습니다.

## 코드 지도

- [ManagedAssetAttribute](../Runtime/ManagedAssetAttribute.cs)
- [ManagedAssetCollectionAttribute](../Runtime/ManagedAssetCollectionAttribute.cs)
