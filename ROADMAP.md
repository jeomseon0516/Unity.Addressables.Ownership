# Addressables Ownership 로드맵

## 0.1

- 기존 Asset lease 및 prefab instance handle을 생성 코드가 직접 보관
- `[ManagedAsset]` 생성 setter를 통한 교체 및 owner 파괴 자동 해제
- 독립 asset retain 및 lease/instance handle ownership transfer 경로
- `IReadOnlyList<T>` 기반 Addressables collection 자동 수명 관리
- 실행 가능한 TextAsset Addressables Scene Sample

## 이후

- 조건 분기와 반복문을 포함하는 Control Flow Graph 기반 borrowed asset escape 진단
- Collection 부분 실패·취소 및 prefab 외부 Destroy 정책과의 통합 검증
