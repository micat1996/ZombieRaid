using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터 공격을 담당하는 컴포넌트입니다.
public sealed class PlayerCharacterAttack : MonoBehaviour
{
	[Header("왼쪽 미사일 발사 위치")]
	[SerializeField] private Transform _MissileFireLeftPos;

	[Header("오른쪽 미사일 발사 위치")]
	[SerializeField] private Transform _MissileFireRightPos;

	[Header("미사일 발사 딜레이")]
	[SerializeField] private float _MissileDelay = 0.1f;

	[Header("미사일 개수")]
	[SerializeField] private int _MissileCount = 5;

	[Header("미사일 최소 / 최대 속력")]
	[SerializeField] private float _MissileSpeedMin = 15.0f;
	[SerializeField] private float _MissileSpeedMax = 40.0f;

	[Header("회전시킬 미사일 오브젝트")]
	[SerializeField] private GameObject _MissileObjectToRotate;

	[Header("미사일 yaw 회전 속도")]
	[SerializeField] private float _MissileYawRotationRate = 360.0f;

	// 마지막 미사일 발사 시간을 저장할 변수
	private float _LastFireTime;

	// 미사일 오브젝트 풀
	private ObjectPool<PlayerMissile> _MissilePool = new ObjectPool<PlayerMissile>();

	// 미사일 오브젝트 프리팹
	private PlayerMissile _PlayerMissilePrefab;

	// 플레이어 캐릭터를 참조할 변수
	private PlayerableCharacter _PlayerableCharacter;



	


	private void Awake()
	{
		_PlayerableCharacter = GetComponent<PlayerableCharacter>();

		// 미사일 오브젝트 프리팹 로드
		_PlayerMissilePrefab = ResourceManager.Instance.LoadResource<GameObject>(
			"PlayerMissilePrefab",
			"Prefabs/Projectile/PlayerMissile").GetComponent<PlayerMissile>();
	}

	private void Update()
	{
		// 미사일을 발사합니다.
		FireMissile();
	}

	// 미사일 오브젝트를 회전시킵니다.
	// 미사일 ㅗㅇ브젯ㄱ트로 옮기기
	private void RotateMissileObject()
	{
		_MissileObjectToRotate.transform.eulerAngles += Vector3.up * _MissileYawRotationRate * Time.deltaTime;
	}

	// 미사일을 발사합니다.
	private void FireMissile()
	{
		// 미사일 오브젝트를 생성하여 반환합니다.
		PlayerMissile CreateMissileObject() => _MissilePool.GetRecycledObject() ??
				_MissilePool.RegisterRecyclableObject(Instantiate(_PlayerMissilePrefab));


		// 발사 위치를 회전시킵니다.
		void RotateFirePosition()
		{
			// 왼쪽, 오른쪽 발사 위치 회전값을 초기화합니다.
			_MissileFireLeftPos.eulerAngles = _MissileFireRightPos.eulerAngles =
				transform.eulerAngles;

			// 왼쪽, 오른쪽 발사 위치의 회전을 변경합니다.
			_MissileFireLeftPos.eulerAngles += new Vector3(0.0f, Random.Range(-50.0f, 50.0f), 0.0f);
			_MissileFireRightPos.eulerAngles += new Vector3(0.0f, Random.Range(-50.0f, 50.0f), 0.0f);
		}








		// 공격용 조이스틱 객체를 얻습니다.
		var attackJoystick = (_PlayerableCharacter.playerController as PlayerController).attackJoystick;

		// 만약 조이스팁 입력이 존재하지 않는다면 실행 X
		if (!attackJoystick.isInput) return;

		// 미사일 딜레이마다 발사시킵니다.
		if (Time.time - _LastFireTime >= _MissileDelay)
		{
			_LastFireTime = Time.time;

			// 미사일 개수만큼 발사시킵니다.
			for (int i = 0; i < _MissileCount; ++i)
			{
				// 발사 위치 회전
				RotateFirePosition();

				// 미사일 생성
				var newLeftPlayerMissile = CreateMissileObject();
				var newRightPlayerMissile = CreateMissileObject();

				// 미사일을 발사시킵니다.
				newLeftPlayerMissile.Fire(
					_MissileFireLeftPos.position, 
					_MissileFireLeftPos.forward, 
					Random.Range(_MissileSpeedMin, _MissileSpeedMax));
				newRightPlayerMissile.Fire(
					_MissileFireRightPos.position,
					_MissileFireRightPos.forward,
					Random.Range(_MissileSpeedMin, _MissileSpeedMax));

			}

		}
	}

}
