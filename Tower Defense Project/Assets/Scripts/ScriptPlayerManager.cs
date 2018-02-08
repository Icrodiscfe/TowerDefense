using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptPlayerManager : MonoBehaviour {

	public Transform AbilitysPanel;
	public GameObject AbilityPrefab;
	public List<ScriptableObjectAbility> Abilitys;



	// Use this for initialization
	void Start () {
		IniAbilitys ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IniAbilitys () {
		foreach (ScriptableObjectAbility Ability in Abilitys) {
			if (Ability.Level > 0) {
				Instantiate (AbilityPrefab, AbilitysPanel).GetComponent<ScriptAbilityPrefab> ().SetAbility (Ability);
			}
		}
	}

	public void ButtonAddAbilitys () {
		foreach (ScriptableObjectAbility Ability in Abilitys) {
			if (Ability.Level == 0) {
				Ability.AddAbility ();
				Instantiate (AbilityPrefab, AbilitysPanel).GetComponent<ScriptAbilityPrefab> ().SetAbility (Ability);
			}
		}
	}
}


