using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터 오브젝트를 나타내기 위한 컴포넌트입니다.
public sealed class PlayerableCharacter : PlayerableCharacterBase
{

	public PlayerCharacterMovement movement { get; private set; }

	private void Awake()
	{
		movement = GetComponent<PlayerCharacterMovement>();
	}
}
