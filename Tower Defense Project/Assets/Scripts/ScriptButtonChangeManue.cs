using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScriptButtonChangeManue : MonoBehaviour, IPointerUpHandler {

	public RectTransform PabelToSetActive, PanelToSetInactive;

	RectTransform PanelRectTransform;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerUp (PointerEventData data) {
		PabelToSetActive.gameObject.SetActive (true);
		PabelToSetActive.Translate (-PabelToSetActive.localPosition.x, -PabelToSetActive.localPosition.y, 0f);
		PanelToSetInactive.gameObject.SetActive (false);
	}
}
