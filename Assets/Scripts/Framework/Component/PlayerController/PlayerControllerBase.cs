using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerBase : MonoBehaviour
{
	[Header("기본으로 생성될 ScreenInstance")]
	[SerializeField] private ScreenInstance _ScreenInstancePrefab;

	public PlayerableCharacterBase playerableCharacter { get; private set; }
	public ScreenInstance screenInstance { get; private set; }
	

	// UI Canvas 를 생성합니다.
	protected virtual void CreateUICanvas()
	{
		screenInstance = Instantiate(_ScreenInstancePrefab);

		var eventSystem = new GameObject();
		eventSystem.AddComponent<EventSystem>();
		eventSystem.AddComponent<StandaloneInputModule>();
	}


	// 캐릭터를 생성합니다.
	public void CreatePlayerableCharacter(PlayerableCharacterBase prefab)
	{
		playerableCharacter = (prefab == null) ? null : Instantiate(prefab);


		// 캐릭터와 연결
		playerableCharacter?.OnControllerConnected(this);

		// UI Canvas 생성
		CreateUICanvas();
	}



	// 컨트롤 회전을 설정합니다.
	public void SetControlRotation(Vector3 eulerAngles) => transform.eulerAngles = eulerAngles;
	public void SetControlRotation(Quaternion quaternion) => transform.rotation = quaternion;

	// 회전값을 더합니다.
	public void AddPitchAngle(float value)
	{
		var eulerAngle = transform.eulerAngles;
		eulerAngle.x += value;
		transform.eulerAngles = eulerAngle;
	}

	public void AddYawAngle(float value)
	{
		var eulerAngle = transform.eulerAngles;
		eulerAngle.y += value;
		transform.eulerAngles = eulerAngle;
	}

	public void AddRollAngle(float value)
	{
		var eulerAngle = transform.eulerAngles;
		eulerAngle.z += value;
		transform.eulerAngles = eulerAngle;
	}

	// 회전을 얻습니다.
	public Vector3 GetControlRotationToEuler() => transform.eulerAngles;
	public Quaternion GetControlRotationToQuaternion() => transform.rotation;



}
