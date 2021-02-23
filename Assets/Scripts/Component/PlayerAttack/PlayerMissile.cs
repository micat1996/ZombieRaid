using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileMovement))]
public sealed class PlayerMissile : MonoBehaviour,
	IObjectPoolable
{
	// 함께 사용되는 ProjectileMovement 를 나타냅니다.
	private ProjectileMovement _ProjectileMovement;

	// 미사일 발사 초기 위치를 저장합니다.
	/// - 미사일 비활성화 시 사용됩니다.
	private Vector3 _InitialPosition;

	public bool canRecyclable { get; set; }
	public Action onRecycleStartEvent { get; set; }

	private void Awake()
	{
		_ProjectileMovement = GetComponent<ProjectileMovement>();
	}
	
	// 미사일을 발사시킵니다.
	public void Fire(Vector3 initialPosition,
		Vector3 direction, float speed)
	{

		// 오브젝트 위치를 초기 위치로 설정합니다.
		transform.position = _InitialPosition = initialPosition;

		// 오브젝트를 활성화시킵니다.
		gameObject.SetActive(true);

		// 투사체 이동 컴포넌트 내용을 초기화
		_ProjectileMovement.m_Direction = direction;
		/// - 방향 설정

		_ProjectileMovement.m_Speed = speed;
		/// - 속력 설정
	}
}
