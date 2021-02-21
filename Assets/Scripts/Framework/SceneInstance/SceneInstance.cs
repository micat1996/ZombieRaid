using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 씬을 나타낼 때 사용될 클래스.
// 각각 씬에 대한 규칙을 정의하는 클래스입니다.
public class SceneInstance : MonoBehaviour
{
	[Header("플레이어 컨트롤러 프리팹을 전달합니다.")]
	[Tooltip("생성된 객체는 PlayerManager 형식 객체를 통해 얻을 수 있습니다.")]
	[SerializeField] protected PlayerControllerBase m_PlayerControllerPrefab;

	[Header("플레이어블 캐릭터 프리팹을 전달합니다.")]
	[Tooltip("생성된 객체는 PlayerControllerBase 형식 객체를 통해 얻을 수 있습니다.")]
	[SerializeField] protected PlayerableCharacterBase m_PlayerableCharacterPrefab;

	protected virtual void Awake()
	{
		SceneManager.Instance.sceneInstance = this;
		PlayerManager.Instance.CreatePlayerController(
			m_PlayerControllerPrefab, m_PlayerableCharacterPrefab);
	}

	protected virtual void OnDestroy()
	{
		SceneManager.Instance.sceneInstance = null;
	}

}

