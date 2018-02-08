using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptInputFieldTest : MonoBehaviour {

	[SerializeField]
	Text OldText = null;
	[SerializeField]
	TMP_Text NewText = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		NewText.text = OldText.text;
	}
}
