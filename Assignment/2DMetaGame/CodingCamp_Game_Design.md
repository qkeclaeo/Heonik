
# 🎮 CodingCamp 2D 메타버스 게임 설계서

## 1. 프로젝트 개요 및 목적

| 항목 | 내용 |
|------|------|
| **프로젝트명** | CodingCamp |
| **장르** | 2D 메타버스 + 미니게임 통합형 |
| **기획 배경** | Unity 기초 학습을 통해 배운 2D 물리, 상호작용, UI, 전투 시스템 등을 하나의 프로젝트 안에서 실습하고 정리하는 경험 제공 |
| **목표 플랫폼** | PC (WebGL or Windows) |
| **플레이 방식** | 플레이어는 CodingCamp 마을을 자유롭게 이동하며 탐험한다. 특정 오브젝트와 상호작용하면 미니게임 씬으로 전환된다. 미니게임이 종료되면 점수가 기록되고 다시 마을 씬으로 복귀된다. |
| **주요 기능 요약** | 2D 캐릭터 WASD 이동, 오브젝트 상호작용, 씬 전환, Stack/Flappy 미니게임, 점수 기록 및 UI 표시 |

---

## 2. 전체 시스템 개요도

```
TitleScene → TownScene → [StackGameScene / FlappyGameScene] → Result UI → TownScene 복귀
```

---

## 3. 플레이어 시스템

- 이동: WASD, Rigidbody2D, velocity
- 상호작용: Trigger + F 키 입력
- 카메라: 플레이어 추적 (LateUpdate + Lerp)

---

## 4. 맵 설계 및 인터랙션

- 마을 구성: 안내판, 포탈(Stack/Flappy), NPC, 점수판
- 상호작용 구조: OnTriggerEnter2D + Input.GetKeyDown
- 수동 배치 방식 (무료 에셋 활용)

---

## 5. 미니게임 기획

### A. Stack 미니게임
- 블록을 정확히 쌓으며 점수 획득
- 오차 발생 시 블록 잘림 → 실패 시 게임 오버
- 점수 = 쌓은 블록 수

### B. FlappyBird 미니게임
- 장애물 통과하면서 점수 획득
- 클릭 시 위로 점프, 중력으로 낙하
- 점수 = 통과한 파이프 수

- 결과 UI 공통 사용
- 효과음: 점프, 성공, 실패, 배경음 등 추가 가능

---

## 6. UI 구성

| 위치 | 내용 |
|------|------|
| TitleScene | 타이틀 텍스트, 시작 버튼 |
| TownScene | 상호작용 안내, 대화창, 점수판 UI |
| MiniGame | 점수 UI, 결과창 (재시작, 마을로 복귀) |

---

## 7. 점수 저장 시스템

- PlayerPrefs 사용: `"HighScore_Stack"`, `"HighScore_Flappy"`
- 결과 UI에서 갱신 여부 판정 후 저장
- 점수판 오브젝트와 상호작용 시 마을 내에서도 확인 가능

---

## 8. 카메라 시스템

- `CameraFollow.cs` 사용
- LateUpdate에서 플레이어 위치 따라가도록 구현
- Vector3.Lerp로 부드럽게 추적

---

## 9. 기술 스택 요약

| 항목 | 내용 |
|------|------|
| Rigidbody2D / Collider2D | 캐릭터, 블록, 장애물 등 |
| Prefab / Trigger | 미니게임, 인터랙션 오브젝트 |
| SceneManager | 씬 전환 |
| UI / Canvas / Text | 점수, 안내, 대화창 |
| PlayerPrefs | 점수 저장 |
| AudioSource / AudioClip | 효과음 처리 |

---

## 10. 전체 씬 흐름도 요약

```
┌────────────────────┐
│     TitleScene     │
└────────┬───────────┘
         ▼
┌────────────────────┐
│     TownScene      │
│   ◉ 포탈(Stack)    │
│   ◉ 포탈(Flappy)   │
│   ◉ 안내판/NPC/점수판│
└────┬──────┬───────┘
     ▼      ▼
┌────────┐ ┌────────┐
│ Stack  │ │ Flappy │
│ Game   │ │ Game   │
└──┬─────┘ └──┬─────┘
   ▼           ▼
┌────────────────────┐
│    Result UI       │
└────────┬───────────┘
         ▼
┌────────────────────┐
│     TownScene      │
└────────────────────┘
```
