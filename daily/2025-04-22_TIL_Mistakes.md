---
title: "배열과 리스트에서 헷갈렸던 실수 모음"
date: 2025-04-22
categories: [TIL]
tags: [C#, 배열, 리스트, 실수정리]
---

## 😵 오늘 실제로 겪은 실수들

---

### 1. 배열에 `.Add()` 쓰기

```csharp
int[] nums = new int[3];
nums.Add(4); // ❌ 컴파일 오류
```

> 배열은 **고정된 크기**라서 `Add()` 안 됨.  
> → `List<int> nums = new List<int>();` 를 써야 한다.

---

### 2. `foreach` 안에서 값 변경 시도

```csharp
foreach (var num in arr)
{
    num = 0; // ❌ 수정 불가
}
```

> `foreach`는 **읽기 전용 반복문**이다. 값을 수정하려면 `for`문을 써야 한다.

---

### 3. 배열 인덱스 초과 접근

```csharp
int[] arr = new int[2];
arr[2] = 100; // ❌ IndexOutOfRangeException
```

> 배열의 인덱스는 항상 `0 ~ Length-1`까지!  
> `arr[2]`는 세 번째 요소인데, 두 칸짜리 배열엔 존재하지 않는다.

---

### 4. 리스트 선언만 하고 초기화 안 함

```csharp
List<int> list;
list.Add(1); // ❌ NullReferenceException
```

> `new` 없이 Add하면 에러남  
> `List<int> list = new List<int>();`로 꼭 초기화할 것

---

### 5. Length vs Count 혼동

```csharp
int[] arr = new int[5];
arr.Count // ❌ 배열은 Count 없음!
```

> 배열은 `.Length`, 리스트는 `.Count`  
> 헷갈리지 말자!

---

## 🧠 느낀 점

- 배열과 리스트는 비슷해 보여도 구조와 사용법이 꽤 다르다.
- 자동완성에 의존하면 헷갈릴 수 있으니 명확히 구분해서 기억해야 한다.
- 실수하면서 진짜 내 것이 되는 느낌이 들었다.
