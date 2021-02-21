using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class VirtualJoystick : MonoBehaviour,
	IDragHandler, IPointerDownHandler, IPointerUpHandler
/// - IDragHandler : 드래깅 콜백을 받기 위해 구현해야 하는 인터페이스
/// - IPointerDownHandler : 클릭 입력 콜백을 받기 위해 구현해야 하는 인터페이스
/// - IPointerUpHandler : 클릭 입력 끝 콜백을 받기 위해 구현해야 하는 인터페이스
{
	// 사용되는 이미지 컴포넌트
	[Header("Joystick")]
	[SerializeField] private Image _JoystickThumbImage;
	[SerializeField] private float _JoystickMaxRadius = 60.0f;

	// 조이스틱 축 값을 저장할 변수입니다.
	public Vector2 inputAxis { get; private set; }

	// 조이스틱 입력중을 나타냅니다.
	public bool isInput { get; private set; }



	// RectTransform Component 를 나타냅니다.
	public RectTransform rectTransform { get; private set; }


	private void Awake()
	{
		rectTransform = transform as RectTransform;
	}


	public void OnDrag(PointerEventData eventData)
	{
		// 입력된 위치를 저장합니다.
		Vector2 inputPos = eventData.position / GameStatics.screenRatio;
		/// - 실제 화면에 입력된 위치에서 화면 비율만큼 나눕니다.

		// 입력된 위치에서 배경 위치를 뺍니다.
		inputPos -= rectTransform.anchoredPosition;

		// 조이스틱을 가둡니다.
		inputPos = (Vector2.Distance(Vector2.zero, inputPos) < _JoystickMaxRadius) ?
			inputPos : inputPos.normalized * _JoystickMaxRadius;

		// 조이스틱 위치를 설정합니다.
		_JoystickThumbImage.rectTransform.anchoredPosition = inputPos;

		inputAxis = inputPos / _JoystickMaxRadius;
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
		isInput = true;
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		isInput = false;
		_JoystickThumbImage.rectTransform.anchoredPosition = inputAxis = Vector2.zero;
	}
}
