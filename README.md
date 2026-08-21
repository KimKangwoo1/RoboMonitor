# 🤖 RoboMonitor

> **WPF 기반 로봇 제어 및 상태 모니터링 학습 프로젝트**

RoboMonitor는 **WPF의 기본 구조와 데이터 바인딩을 이해하기 위해 만든 개인 학습 프로젝트**입니다.  
실제 로봇 장비가 없는 환경에서 동작을 확인할 수 있도록 간단한 시뮬레이션 데이터를 사용했고, 로봇의 상태 확인과 기본 제어 흐름을 화면으로 구성했습니다.

이 프로젝트를 진행하면서 WPF에서 화면과 로직을 분리하는 **MVVM 구조**와, View와 ViewModel을 연결하는 **Data Binding**의 기본 개념을 이해하는 데 중점을 두었습니다.

## 🎬 시연 영상

[YouTube에서 시연 영상 보기](https://youtu.be/9xBM6WRsdQs)

---

## 🎯 프로젝트 목적

- WPF 프로젝트의 기본 구조 익히기
- XAML을 이용한 화면 구성 경험
- MVVM 구조의 기본 개념 이해
- Data Binding을 이용한 화면과 데이터 연결 이해
- 로봇 제어 화면의 기본 흐름 경험
- 실제 실행과 테스트를 통해 코드 동작 확인

---

## 🛠 사용 기술

| 구분 | 내용 |
|---|---|
| Language | C# |
| Framework | WPF / .NET 8 |
| Architecture | MVVM |
| UI | XAML, Data Binding |
| IDE | Visual Studio |
| Version Control | Git / GitHub |

---

## 📌 주요 기능

### 로봇 상태 확인
- 연결 상태 표시
- RUN / STOP 상태 표시
- AUTO / MANUAL 모드 표시
- Servo 상태 표시
- 속도, 온도, 가동 시간 표시
- Joint 1~4 값 표시

### 기본 제어
- Connect / Disconnect
- Servo ON / OFF
- Start / Stop
- AUTO / MANUAL 모드 변경
- Emergency Stop
- Reset E-Stop

### 알람 및 로그
- Emergency Stop 발생 시 알람 표시
- 사용자의 주요 조작 내용을 로그로 기록

### 시뮬레이션
실제 로봇 장비가 없기 때문에 프로그램 내부에서 속도, 온도, Joint 값이 변하도록 구성해 화면의 데이터 변화를 확인했습니다.

---

## 🔄 프로젝트에서 이해한 구조

```text
화면 (View)
    │
    │ Data Binding
    ▼
ViewModel
    │
    ▼
로봇 시뮬레이션 데이터
```

프로젝트를 진행하면서 **화면에 모든 동작을 직접 작성하는 것이 아니라, 화면과 데이터를 분리해서 연결할 수 있다는 점**을 배웠습니다.

- **View**: 화면을 구성하는 부분
- **ViewModel**: 화면에 보여줄 값과 버튼 동작을 관리하는 부분
- **Data Binding**: View와 ViewModel의 데이터를 연결하는 기능

세부적인 WPF 기능들은 이 프로젝트의 실제 코드를 다시 확인하면서 계속 학습하고 있습니다.

---

## 🧩 프로젝트 구조

```text
RoboMonitor/
├── RoboMonitor.sln
├── src/
│   └── RoboMonitor/
│       ├── Commands/
│       ├── Models/
│       ├── Services/
│       ├── ViewModels/
│       ├── App.xaml
│       ├── MainWindow.xaml
│       ├── MainWindow.xaml.cs
│       └── RoboMonitor.csproj
├── .gitignore
└── README.md
```

폴더는 화면, 데이터, 제어 로직을 구분하기 위해 역할별로 나누어 구성했습니다.

---

## ✅ 실행 확인

Windows + Visual Studio 환경에서 직접 실행해 아래 기본 흐름을 확인했습니다.

```text
Connect
  ↓
Servo ON
  ↓
Start
  ↓
상태 값 변화 확인
  ↓
Stop
```

또한 AUTO / MANUAL 변경, Emergency Stop, Reset E-Stop, Alarm 및 Log 동작도 확인했습니다.

처음 실행할 때 `.NET 8 Desktop Runtime`이 설치되어 있지 않아 실행되지 않았고, 런타임 설치 후 정상적으로 실행되는 것을 확인했습니다.

---

## 📚 프로젝트를 통해 배운 점

이 프로젝트를 시작할 때는 WPF의 세부 구조를 모두 이해하고 있지는 않았습니다. 프로젝트를 직접 실행하고 코드를 확인하면서 다음 내용을 기본 수준에서 이해하게 되었습니다.

- XAML로 WPF 화면을 구성하는 방법
- View와 ViewModel을 분리하는 MVVM 구조
- Data Binding을 이용해 데이터와 UI를 연결하는 방법
- 값이 변경되면 화면에도 변경된 값이 반영되는 흐름
- 버튼 동작을 ViewModel과 연결하는 방식
- 알람과 로그처럼 화면에 항목이 추가되는 데이터 처리 방식

아직 WPF의 모든 기능을 깊게 이해한 수준은 아니며, 이 프로젝트 코드를 기준으로 핵심 개념을 계속 복습하고 있습니다.

---

## ▶️ 실행 방법

1. Repository Clone 또는 ZIP 다운로드
2. `RoboMonitor.sln` 실행
3. Visual Studio에서 프로젝트 열기
4. `.NET 8 Desktop Runtime` 설치 여부 확인
5. 프로젝트 실행

---

## 📌 Project Info

| 항목 | 내용 |
|---|---|
| 프로젝트 | RoboMonitor |
| 종류 | WPF 개인 학습 프로젝트 |
| 목적 | WPF / MVVM / Data Binding 기본 구조 학습 |
| 환경 | Windows / Visual Studio / .NET 8 |
| 상태 | v1 구현 및 실행 확인 완료 |
