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

	[Header("투사체의 반지름입니다.")]
	public float m_ProjectileRadius;

	// 투사체 충돌을 감지할 레이어입니다.
	public int detectableLayer { get; set; } = 1;

	// 투사체와 다른 오브젝트간의 겹침이 발생하는 경우 호출되는 대리자.
	public System.Action<Collider> onProjectileOverlapped { get; set; }

	protected virtual void FixedUpdate()
	{
		// 투사체 겹침을 검사합니다.
		ProjectileOverlapCheck();
	}

	protected virtual void Update()
	{
		// 투사체를 이동시킵니다.
		MoveProjectile();
	}

	// 투사체 겹침을 확인합니다.
	/* 대미지를 처리하는 2가지 방법
	   OnTrigger/CollisionEnter() 를 이용한 대미지 처리
	   (AntarticSurvival 에서 사용함)
	     - 방법
	       1. OnTriggerEnter(), OnCollisionEnter() 메서드를 이용하여 
		      겹친 오브젝트가 존재하는지 검사.
	       2. 겹친 오브젝트가 가진 대미지 처리 컴포넌트를 얻어 대미지 처리
	     - 장점
	       - 꽤 간단하게 처리할 수 있다.
		   - 드는 비용이 싸다.
	     - 단점
	       - 만약 피충돌체중 하나라도 너무 빠르게 이동한다면 인식이 불가능해짐.
		 - 결론
		   - 해당 방식은 피충돌체가 느리게 이동하거나, 
		     대미지 처리가 크게 중요하지 않는 경우 사용하기 적합하다.
	   
	   Raycast 를 이용한 대미지 처리
	     - 방법
	       1. 매번 이동 방향으로 속력만큼의 길이로 Ray 를 발사함.
	       2. Ray 에 감지된 객체가 존재하는지 검사.
	       3. 감지된 오브젝트가 가진 대미지 처리 컴포넌트를 얻어 대미지 처리
	     - 장점
	       - 피충돌체가 아무리 빠르게 이동해도 정확하게 감지함.
	     - 단점
	       - 첫 번째 방식에 비해 아주 살짝 복잡하다.
	       - 첫 번째 방식에 비해 비용이 비싸다.
		 - 결론
	       - 해당 방식은 피충돌체가 빠르게 이동하거나, 
		     대미지 처리가 굉장히 중요한 경우 사용하기 적합하다.
	 */

	/* Raycast
	 * 광선을 쏴서 계산하는 방식
	 * youtube 영상 링크
	 * https://www.youtube.com/watch?v=sLvvDpjtJrE
	 * 
	 * SphereCast, BoxCast, SphereCast
	 * 각각 광선이 아닌, 구체, 박스, 캡슐 모양을 발사하여 계산하는 방식을 의미합니다.
	 * 보통 투사체 겹침 처리에 사용됩니다.
	 * 점이 아닌, 영역을 이용하여 계산할 수 있다는 점이 특징.
	*/
	private void ProjectileOverlapCheck()
	{
		// 현재 위치에서 겹침이 발생했는지 확인합니다.
		var colliders = Physics.OverlapSphere(transform.position, m_ProjectileRadius, detectableLayer);

		// 겹친 객체가 존재한다면
		if (colliders.Length > 0)
		{
			onProjectileOverlapped?.Invoke(colliders[0]);
			return;
		}

		// 레이 정보를 저장합니다.
		Ray ray = new Ray(transform.position, m_Direction);

		// 감지 결과를 저장할 변수
		RaycastHit hit;


		// SphereCast 를 진행합니다.
		/// - SphereCast 는 시작 위치의 겹침을 검사하지 않음.
		/// - 그렇기 때문에 시작 위치에서 OverlapSphere 를 통한 겹침 검사가 필요함.
		if (Physics.SphereCast(ray.origin, m_ProjectileRadius,
			ray.direction, out hit, m_Speed * Time.deltaTime, detectableLayer))
		{
			onProjectileOverlapped?.Invoke(hit.collider);
		}
		/// - Physics.SphereCast : SphereCast 를 진행하며, 감지한 객체가 존재한다면 true 를 리턴합니다.
		///		Vector3			origin : 시작 위치
		///		float			radius : 구체의 반지름
		///		Vector3			direction : 방향을 지정합니다.
		///		out RaycastHit	hitInfo : 감지 결과를 저장할 변수
		///		float			maxDistance : 감지 거리
		///		int				layerMask : 감지 Layer
	}

	// 투사체를 이동시킵니다.
	private void MoveProjectile()
	{
		transform.Translate(
			m_Direction * m_Speed * Time.deltaTime,
			Space.Self);
	}

}
