using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerableCharacter : PlayerableCharacterBase
{

	public PlayerCharacterMovement movement { get; private set; }

	private void Awake()
	{
		movement = GetComponent<PlayerCharacterMovement>();
	}
}
