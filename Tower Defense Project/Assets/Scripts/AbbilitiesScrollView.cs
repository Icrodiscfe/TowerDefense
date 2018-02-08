using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbbilitiesScrollView : MonoBehaviour {

	public RectTransform Contect;
	public RectTransform Ability;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Ability.rect.height);
		Contect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, (50f + Ability.rect.height) * transform.childCount);
	}
}
