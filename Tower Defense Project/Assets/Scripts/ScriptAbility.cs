using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScriptAbility : MonoBehaviour {
	[SerializeField]
	TMP_Text AbilityName = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAbilityName (string _name) {
		AbilityName.text = _name;
	}
}
