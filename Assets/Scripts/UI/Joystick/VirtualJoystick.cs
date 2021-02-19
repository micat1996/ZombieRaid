using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class VirtualJoystick : MonoBehaviour,
	IDragHandler, IPointerDownHandler, IPointerUpHandler
/// - IDragHandler : 드래깅 콜백을 받기 위한 인터페이스
/// - IPointerDownHandler : 클릭 입력 콜백을 받기 위한 인터페이스
/// - IPointerUpHandler : 클릭 입력이 끝 콜백을 받기 위한 인터페이스
{
	// 사용되는 이미지 컴포넌트
	[Header("Thumb Image")]
	[SerializeField] private Image _JoystickThumbImage;


	void IDragHandler.OnDrag(PointerEventData eventData)
	{
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
	}
}
