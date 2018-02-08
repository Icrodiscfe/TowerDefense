using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScriptButtonChangeManue : MonoBehaviour, IPointerUpHandler {

	public RectTransform PabelToSetActive, PanelToSetInactive;

	RectTransform PanelRectTransform;

	public void OnPointerUp (PointerEventData data) {
		if (PabelToSetActive != null) {
			PabelToSetActive.gameObject.SetActive (true);
			PabelToSetActive.Translate (-PabelToSetActive.localPosition.x, -PabelToSetActive.localPosition.y, 0f);
		}
		if (PanelToSetInactive != null) 
			PanelToSetInactive.gameObject.SetActive (false);
	}
}
