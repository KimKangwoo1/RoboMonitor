# 🤖 RoboMonitor

> **WPF MVVM 기반 로봇 제어 및 실시간 모니터링 시스템**

RoboMonitor는 산업용 로봇 제어 프로그램을 가정해 설계한 WPF 개인 프로젝트입니다. 실제 로봇 장비가 없는 환경에서도 동작 흐름을 확인할 수 있도록 **Robot Simulator**를 구성하고, 로봇 상태·제어·알람·로그를 하나의 데스크톱 애플리케이션에서 관리하도록 구현하고 있습니다.

> 🚧 **현재 상태: v1 핵심 기능 코드 구현 완료 / Windows 실행 검증 대기**  
> 현재 코드는 `develop` 브랜치에 구현되어 있으며, Visual Studio에서 실제 실행 확인 후 `main`에 병합할 예정입니다.

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

이 프로젝트의 코드를 기준으로 아래 내용을 복습할 예정입니다.

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
- [ ] Windows Visual Studio 실행 검증
- [ ] 실행 화면 캡처 추가
- [ ] 아키텍처 이미지 추가
- [ ] README 최종 정리
- [ ] `develop` → `main` 병합

---

## ▶️ 실행 환경

현재 프로젝트는 **Windows + Visual Studio + .NET 8 WPF** 환경을 대상으로 합니다.

1. Repository clone
2. `RoboMonitor.sln` 열기
3. .NET 8 SDK 및 WPF 개발 워크로드 확인
4. `RoboMonitor`를 시작 프로젝트로 선택
5. 실행 후 Connect → Servo ON → Start 순서로 동작 확인

> 현재 이 저장소의 v1 코드는 생성되었지만 실제 Windows GUI 실행 검증은 아직 완료되지 않았습니다.

---

## 📌 Project Info

| Item | Description |
|---|---|
| Project | RoboMonitor |
| Type | WPF Desktop Application |
| Architecture | MVVM |
| Target | .NET 8 / Windows |
| Status | Code Implemented, Runtime Verification Pending |
| Repository | `KimKangwoo1/RoboMonitor` |
