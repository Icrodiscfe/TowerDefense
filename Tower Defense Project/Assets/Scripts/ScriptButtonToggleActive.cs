using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScriptButtonToggleActive : MonoBehaviour, IPointerUpHandler {

	public GameObject objectToToggleActive;

	public void OnPointerUp (PointerEventData data) {
		objectToToggleActive.SetActive (!objectToToggleActive.activeInHierarchy);
	}
}
