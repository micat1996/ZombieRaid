using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenInstance : ScreenInstance
{
	[Header("이동을 담당하는 조이스틱")]
	[SerializeField] private VirtualJoystick _MovementJoystick;
	[Header("공격을 담당하는 조이스틱")]
	[SerializeField] private VirtualJoystick _AttackJoystick;

	public VirtualJoystick movementJoystick => _MovementJoystick;
	public VirtualJoystick attackJoystick => _AttackJoystick;




}
