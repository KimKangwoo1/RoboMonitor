# 🤖 RoboMonitor

> **WPF MVVM 기반 로봇 제어 및 실시간 모니터링 시스템**

RoboMonitor는 산업용 로봇 제어 프로그램을 가정해 설계한 WPF 개인 프로젝트입니다. 실제 로봇 장비가 없는 환경에서도 동작 흐름을 확인할 수 있도록 **Robot Simulator**를 구성하고, 로봇 상태·제어·알람·로그를 하나의 데스크톱 애플리케이션에서 관리하도록 구현했습니다.

> ✅ **현재 상태: v1 핵심 기능 구현 및 Windows Visual Studio 전체 동작 검증 완료**  
> Windows 환경에서 앱 실행, 로봇 연결, Servo, Start/Stop, Mode 전환, Emergency Stop, **RESET E-STOP 복구**, Alarm/Log 동작까지 확인했습니다.

---

## 🎯 프로젝트 목표

- WPF의 UI 구성과 데이터 바인딩 구조 이해
- MVVM 패턴을 적용해 View와 로직 분리
- 실시간으로 변경되는 로봇 상태를 UI에 반영
- Command 기반의 로봇 제어 흐름 구현
- 알람 및 로그 데이터를 컬렉션 형태로 관리
- 실제 장비 없이 테스트 가능한 Robot Simulator 구성
- 구현한 코드를 직접 설명할 수 있는 수준까지 WPF 핵심 개념 학습

---

## 🛠 기술 스택

| Category | Technology |
|---|---|
| Language | C# |
| UI Framework | WPF |
| Platform | .NET 8 (`net8.0-windows`) |
| Architecture | MVVM |
| UI | XAML, Data Binding |
| State Update | INotifyPropertyChanged |
| Collection | ObservableCollection |
| Command | ICommand / RelayCommand |
| Timer | DispatcherTimer |
| Development | Visual Studio |
| Version Control | Git, GitHub |

---

## 📌 v1 구현 기능

### Dashboard
- 로봇 연결 상태 표시
- RUN / STOP 상태 표시
- Manual / Auto 모드 표시
- 속도 및 모터 온도 표시
- 가동 시간 표시
- Joint 1~4 위치 표시

### Robot Control
- Connect / Disconnect
- Servo ON / OFF
- Start / Stop
- Emergency Stop / Reset
- Manual / Auto 모드 전환
- 상태에 따른 Command 활성화 조건 적용

### Robot Simulator
- 실제 로봇 없이 테스트 가능한 상태 데이터 생성
- Joint 위치, 속도, 온도 실시간 변경
- RUN/STOP, Servo, Mode 상태를 시뮬레이션 데이터에 반영

### Alarm & Log
- 고온 Warning 알람 생성
- Emergency Stop Error 알람 생성
- 동작 로그 실시간 기록
- `ObservableCollection` 기반 UI 자동 갱신

---

## ✅ Windows 실행 검증

Windows + Visual Studio 환경에서 실제 실행해 아래 동작을 확인했습니다.

- 애플리케이션 정상 실행
- Robot Connected 상태 표시
- Servo ON 동작
- Robot Start / Stop 동작
- Manual / Auto 모드 전환
- Speed / Temperature / Joint 1~4 값 UI 반영
- Operation Time 갱신
- Emergency Stop 동작
- Emergency Stop 알람 생성
- **RESET E-STOP 후 Safety 상태가 `NORMAL`로 복구**
- **Operation Log에 `Emergency stop reset` 기록 확인**
- Operation Log 실시간 누적

초기 실행 과정에서 `.NET 8 Desktop Runtime`이 설치되지 않은 환경에서는 실행 시 런타임 설치 안내가 표시되었습니다. `.NET 8 Desktop Runtime` 설치 후 정상 실행을 확인했습니다.

---

## 🧩 프로젝트 구조

```text
RoboMonitor/
├── RoboMonitor.sln
├── src/
│   └── RoboMonitor/
│       ├── Commands/
│       │   └── RelayCommand.cs
│       ├── Models/
│       │   ├── AlarmEntry.cs
│       │   ├── LogEntry.cs
│       │   └── RobotTelemetry.cs
│       ├── Services/
│       │   └── RobotSimulationService.cs
│       ├── ViewModels/
│       │   ├── MainViewModel.cs
│       │   └── ObservableObject.cs
│       ├── App.xaml
│       ├── MainWindow.xaml
│       └── RoboMonitor.csproj
├── .gitignore
└── README.md
```

---

## 🔄 MVVM 구조

```text
View (MainWindow.xaml)
        │
        │ Data Binding / ICommand
        ▼
MainViewModel
        │
        │ 상태 관리 / 제어 요청
        ▼
RobotSimulationService
        │
        ▼
RobotTelemetry / AlarmEntry / LogEntry
```

`MainWindow.xaml.cs`에서는 화면 로직을 직접 처리하지 않고 `MainViewModel`을 `DataContext`로 지정하는 역할만 수행합니다. 화면에 표시되는 값은 Binding으로 연결하고, 버튼 동작은 `ICommand`를 통해 ViewModel의 명령으로 연결합니다.

---

## 📚 WPF 학습 포인트

이 프로젝트의 실제 코드를 기준으로 아래 내용을 복습합니다.

- XAML과 Code-behind의 역할
- DataContext
- Data Binding
- MVVM
- INotifyPropertyChanged
- ObservableCollection
- ICommand / RelayCommand
- CanExecute
- DispatcherTimer
- UI 상태 갱신
- Style / Resource

---

## 🗺 Development Roadmap

- [x] GitHub 저장소 생성
- [x] Visual Studio / WPF용 `.gitignore` 구성
- [x] WPF 프로젝트 생성
- [x] MVVM 기본 구조 구성
- [x] Dashboard 코드 구현
- [x] Robot Simulator 코드 구현
- [x] Robot Control 코드 구현
- [x] Alarm / Log 코드 구현
- [x] 기본 산업용 다크 UI 구성
- [x] Windows Visual Studio 실행 검증
- [x] RESET E-STOP 복구 동작 검증
- [x] v1 핵심 제어 흐름 전체 검증
- [ ] 실행 화면 캡처 GitHub 추가
- [ ] 아키텍처 이미지 추가
- [ ] WPF 핵심 코드 학습 및 Notion 정리

---

## ▶️ 실행 환경

프로젝트는 **Windows + Visual Studio + .NET 8 WPF** 환경을 대상으로 합니다.

1. Repository clone 또는 ZIP 다운로드
2. `RoboMonitor.sln` 열기
3. .NET 8 SDK 및 WPF 개발 워크로드 확인
4. `.NET 8 Desktop Runtime` 설치 확인
5. `RoboMonitor`를 시작 프로젝트로 선택
6. 실행 후 Connect → Servo ON → Start 순서로 동작 확인

---

## 📌 Project Info

| Item | Description |
|---|---|
| Project | RoboMonitor |
| Type | WPF Desktop Application |
| Architecture | MVVM |
| Target | .NET 8 / Windows |
| Status | v1 Implemented / Core Flow Verified |
| Repository | `KimKangwoo1/RoboMonitor` |
