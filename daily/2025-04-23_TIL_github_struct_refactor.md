# 2025-04-23 TIL - C# 구조화 및 실습 기반 정리

## ✅ 작업 요약

- `BattleManager.cs`가 너무 길어진 문제를 해결하기 위해 기능을 분리
- 다음 클래스 파일로 역할 분리:
  - `EnemyPhaseManager.cs` : 몬스터 공격
  - `BattleResultChecker.cs` : 전투 종료 판정
  - `ExpSet.cs` : 경험치 획득 및 레벨업
  - `LevelExpCalculator.cs` : 다음 레벨 경험치 계산

## 📘 정적 클래스 (`static class`) 이해

### 개념
- 인스턴스 생성 없이 클래스명으로 직접 메서드 호출
- 상태를 저장하지 않고 계산만 담당
- 대표 예: `Console`, `Math`

### 적용 사례
```csharp
public static class LevelExpCalculator
{
    public static int GetNextLevelExp(int currentLevel)
    {
        return 30 + (currentLevel - 1) * 10;
    }
}
```

## 💡 깨달은 점

- 상태가 필요 없는 계산 로직은 정적 클래스로 빼면 가독성과 재사용성이 좋음
- 기능별 `.cs` 분리는 협업 시 책임 구분을 명확하게 해줌
