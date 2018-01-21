using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbbilitiesScrollView : MonoBehaviour {

	public RectTransform Contect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Contect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 200f + 250f * transform.childCount);
	}
}
