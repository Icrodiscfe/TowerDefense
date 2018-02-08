using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScriptButtonState : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler {

	public bool isPressed;


	public void OnPointerDown (PointerEventData data) {
		isPressed = true;
	}

	public void OnPointerUp (PointerEventData data) {
		isPressed = false;
	}	
	public void OnPointerExit (PointerEventData data) {
		isPressed = false;
	}
}
