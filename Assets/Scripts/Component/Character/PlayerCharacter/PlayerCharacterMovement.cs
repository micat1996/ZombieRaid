using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerCharacterMovement : MonoBehaviour
{
	[Header("이동 속력을 나타냅니다.")]
	[SerializeField] private float _MoveSpeed = 6.0f;

	[Header("제동력을 나타냅니다.")]
	[SerializeField] private float _BrackingForce = 6.0f;

	private PlayerableCharacter _PlayerableCharacter;
	private CharacterController _CharacterController;

	// 이전 이동 속도를 저장합니다.
	/// - 부드러운 이동을 구현하기 위해 사용됩니다.
	private Vector3 _PrevMoveVelocity;

	private void Awake()
	{
		_PlayerableCharacter = GetComponent<PlayerableCharacter>();
		_CharacterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		Movement();
	}


	// 캐릭터 이동을 구현합니다.
	private void Movement()
	{
		// 이동 입력 축 값을 저장합니다.
		Vector3 inputMovementAxis = (_PlayerableCharacter.playerController as PlayerController).inputMovementAxis;

#if UNITY_EDITOR
		// 에디터에서 실행할 경우 컴파일됩니다.

		// 축 입력 값을 저장합니다.
		Vector3 pcInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));

		// 이동 방향을 지정합니다.
		if (pcInput.magnitude > 0.1f) inputMovementAxis = pcInput;
		/// - pcInput.magnitude : 벡터의 길이를 반환합니다.
#endif

		// 속도를 저장합니다.
		Vector3 moveVelocity = inputMovementAxis * _MoveSpeed;

		// 이동 속도를 설정합니다.
		_PrevMoveVelocity = Vector3.Lerp(
			_PrevMoveVelocity,
			moveVelocity,
			_BrackingForce * Time.deltaTime);
		/// - Vector3.Lerp(Vector3 a, Vector3 b, float t) : a 부터 b 까지 (t * 100)% 만큼
		///   이동시킨 값을 반환합니다.
		/// - ex) Vector3.Lerp(Vector3.zero, Vector3.one, 0.5f) = (0.5f, 0.5f, 0.5f)

		// 캐릭터를 이동시킵니다.
		_CharacterController.SimpleMove(_PrevMoveVelocity);
		/// - ChararcterController Instance.SimpleMove(Vector3 speed) : 캐릭터를 
		///   speed 의 속도로 이동시킵니다.
		/// - 간단한 이동을 구현할 때 사용하며, 점프 기능이 없는 캐릭터 이동에 사용됩니다.
	}
}
