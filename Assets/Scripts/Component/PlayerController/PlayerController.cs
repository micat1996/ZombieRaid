using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : PlayerControllerBase
{
	// 플레이어 입력 값을 저장합니다.
	public Vector3 inputMovementAxis { get; private set; }

	// 플레이어 공격 입력 값을 저장합니다.
	public Vector3 inputAttackAxis { get; private set; }


	private void Update()
	{
		// 입력 축 값을 갱신합니다.
		UpdateInputAxisValue();

		// 컨트롤러를 회전시킵니다.
		RotateController();
	}

	// 입력 축 값을 갱신합니다.
	private void UpdateInputAxisValue()
	{
		var movementAxis = (screenInstance as GameScreenInstance).movementJoystick.inputAxis;
		var attackAxis = (screenInstance as GameScreenInstance).attackJoystick.inputAxis;

		inputMovementAxis = new Vector3(movementAxis.x, 0.0f, movementAxis.y);
		inputAttackAxis = new Vector3(attackAxis.x, 0.0f, attackAxis.y);
	}

	// 컨트롤러를 회전시킵니다.
	private void RotateController()
	{
		if (inputAttackAxis.magnitude <= 0.1f) return;

		// 입력 방향을 Y 축 기준 회전 값으로 변경합니다.
		float yawAngle = inputAttackAxis.ToAngle();


		Vector3 eulerAngle = new Vector3(0.0f, yawAngle, 0.0f);

		// 컨트롤러를 회전시킵니다.
		SetControlRotation(eulerAngle);
	}


}
