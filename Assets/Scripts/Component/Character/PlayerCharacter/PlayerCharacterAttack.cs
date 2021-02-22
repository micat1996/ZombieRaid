﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터 공격을 담당하는 컴포넌트입니다.
public sealed class PlayerCharacterAttack : MonoBehaviour
{
	[Header("왼쪽 미사일 발사 위치")]
	[SerializeField] private Transform _MissileFireLeftPos;

	[Header("오른쪽 미사일 발사 위치")]
	[SerializeField] private Transform _MissileFireRightPos;



}