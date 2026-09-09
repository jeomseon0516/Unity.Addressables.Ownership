# 변경 기록

## [0.1.1] - Unreleased

- Addressables 0.4.0의 명시적 Prefab handle 수명 정책을 기본 전제로 갱신했습니다.
- `[ManagedAsset]` 선언 시 생성되는 owner 수명과 borrowed value 계약을 알리는 Analyzer 경고를
  Ownership Core에서 제공합니다.
- 중간 ownership Wrapper와 전용 로드 확장을 제거하고 기존 Addressables lease/handle을 생성 코드가
  직접 보관하도록 변경했습니다.
- 생성된 `Retain{Name}()`과 `Take{Name}()`으로 독립 보유와 ownership 이동을 지원합니다.
- 잘못된 asset/instance Take 요청은 lifetime host에서 분리하기 전에 실패합니다.
- `[ManagedAssetCollection] IReadOnlyList<T>`에 collection lease의 set/clear/retain/take 코드를 생성합니다.

## [0.1.0] - Unreleased

- Addressable asset 및 instance ownership handle과 로드 확장을 추가했습니다.
