# 🤖 RoboMonitor

> **WPF MVVM 기반 로봇 제어 및 실시간 모니터링 시스템**

RoboMonitor는 산업용 로봇 제어 프로그램을 가정해 설계하는 WPF 개인 프로젝트입니다.  
실제 로봇 장비가 없는 환경에서도 동작을 확인할 수 있도록 **Robot Simulator**를 구성하고, 로봇 상태·제어·알람·로그를 하나의 데스크톱 애플리케이션에서 관리하는 것을 목표로 합니다.

> 🚧 **현재 상태: 프로젝트 초기 구성 단계**  
> 아래 기능과 기술은 v1에서 구현할 목표이며, 구현 완료 여부는 개발 진행에 따라 갱신합니다.

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

## 🛠 예정 기술 스택

| Category | Technology |
|---|---|
| Language | C# |
| UI Framework | WPF |
| Platform | .NET |
| Architecture | MVVM |
| UI | XAML, Data Binding |
| State Update | INotifyPropertyChanged |
| Collection | ObservableCollection |
| Command | ICommand |
| Async | async / await |
| Development | Visual Studio |
| Version Control | Git, GitHub |

---

## 📌 v1 구현 예정 기능

### Dashboard
- 로봇 연결 상태 표시
- RUN / STOP 상태 표시
- Manual / Auto 모드 표시
- 속도 및 모터 온도 표시
- 가동 시간 표시
- Joint 1~4 위치 표시

### Robot Control
- Servo ON / OFF
- Start / Stop
- Emergency Stop
- Manual / Auto 모드 전환

### Robot Simulator
- 실제 로봇 없이 테스트 가능한 상태 데이터 생성
- Joint 위치, 속도, 온도 등 실시간 값 변경
- 제어 명령에 따른 상태 변화 구현

### Alarm & Log
- 경고 / 오류 / 정보 알람 표시
- 실시간 로그 추가
- 시간, Level, Message 관리

---

## 🧩 예정 프로젝트 구조

```text
RoboMonitor/
├── Commands/       # ICommand 구현
├── Models/         # Robot, Alarm 등 데이터 모델
├── Services/       # Robot Simulator 및 서비스 로직
├── ViewModels/     # 화면 상태와 명령 관리
├── Views/          # WPF XAML 화면
├── Resources/      # Style, ResourceDictionary
├── docs/           # 아키텍처 및 실행 화면
├── App.xaml
└── RoboMonitor.csproj
```

---

## 🔄 설계 방향

```text
View (XAML)
    │
    │ Data Binding / Command
    ▼
ViewModel
    │
    │ Service 호출
    ▼
Robot Service / Simulator
    │
    ▼
Model
```

View는 화면 표현에 집중하고, ViewModel이 화면에 필요한 상태와 명령을 관리하도록 구성할 예정입니다.  
Robot Simulator는 실제 장비 연결부와 분리해 이후 TCP/IP 등의 실제 통신 방식으로 확장할 수 있도록 설계합니다.

---

## 📚 WPF 학습 포인트

이 프로젝트에서는 기능 구현과 함께 아래 개념을 코드 기준으로 정리합니다.

- XAML과 Code-behind의 역할
- DataContext
- Data Binding
- Binding Mode
- MVVM
- INotifyPropertyChanged
- ObservableCollection
- ICommand / RelayCommand
- async / await
- UI Thread와 Dispatcher
- ResourceDictionary와 Style

---

## 🗺 Development Roadmap

- [x] GitHub 저장소 생성
- [x] 프로젝트 README 초기 구성
- [x] Visual Studio / WPF용 `.gitignore` 구성
- [ ] WPF 프로젝트 생성
- [ ] MVVM 기본 구조 구성
- [ ] Dashboard 구현
- [ ] Robot Simulator 구현
- [ ] Robot Control 구현
- [ ] Alarm / Log 구현
- [ ] UI 개선
- [ ] 실행 화면 및 아키텍처 문서 추가
- [ ] README 최종 정리

---

## 📌 Project Info

| Item | Description |
|---|---|
| Project | RoboMonitor |
| Type | WPF Desktop Application |
| Architecture | MVVM |
| Status | In Development |
| Repository | `KimKangwoo1/RoboMonitor` |
