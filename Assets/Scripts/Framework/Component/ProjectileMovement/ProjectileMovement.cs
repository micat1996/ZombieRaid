using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 투사체 이동을 구현하는 컴포넌트입니다.
public class ProjectileMovement : MonoBehaviour
{
	[Header("투사체의 속력")]
	public float m_Speed = 2.0f;

	[Header("투사체의 방향")]
	public Vector3 m_Direction = Vector3.forward;

	// 투사체와 다른 오브젝트간의 겹침이 있
	public System.Action<RaycastHit> onProjectileOverlapped { get; set; }

}
