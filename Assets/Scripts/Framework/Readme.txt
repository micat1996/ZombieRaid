Single
* GameManager
- 게임 전체를 관리할 객체를 만들기 위한 클래스
- 관리할 대상의 종류에 따라 SubManager 객체를 가지며 관리를 세분화한다.
- 어디서든지 해당 객체로의 쉬운 접근이 가능해야 함.

* AudioManager
- 사운드 관련 객체들을 관리한다.
* PlayerManager
- 플레이어와 관련된 내용을 관리한다.
* ResourceManager
- 리소스 로드와 관련된 내용을 관리한다.
* SceneManager
- 씬과 관련된 내용을 관리한다.


* ObjectPool<T>
- 오브젝트 풀링을 위한 객체를 만들기 위한 클래스
- 풀링 대상을 형식 매개 변수 T 에 전달한다.
- 풀링이 가능한 형식은 IObjectPoolable 인터페이스를 구현해야 한다.

* SceneInstance
- 씬에 대한 규칙을 정의하는 클래스.
- 사용될 PlayerController 객체를 정의할 수 있어야 한다.
- 사용될 PlayerableCharacter 객체를 정의할 수 있어야 한다.


* PlayerController
- 모든 플레이어 캐릭터에 적용될 내용을 정의한다.
- 사용될 ScreenInstance 객체를 정의할 수 있어야 한다.

*ScreenInsatnce
- 화면에 띄울 최상위 부모 UI 를 나타내기 위한 클래스.
- 관리를 위해 모든 UI 는 해당 컴포넌트를 갖는 오브젝트 하위로 추가되어야 한다.













플레이어 캐릭터 생성
SceneInsatnce::Awake()
PlayerManager::CreatePlayerController()
플레이어 컨트롤러를 생성합니다.

PlayerControllerBase::CreatePlayerableCharacter()
PlayerableCharacter::OnControllerConnected()
캐릭터를 생성하여 컨트롤러와 연결시킵니다.









