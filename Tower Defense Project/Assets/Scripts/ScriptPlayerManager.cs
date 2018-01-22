using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptPlayerManager : MonoBehaviour {

	public Transform AbilitysPanel;
	public GameObject AbilityPrefab;
	public List<TempAbility> Abilitys;

	// Use this for initialization
	void Start () {
		foreach (TempAbility Ability in Abilitys) {
			Debug.Log(Ability.Name + " available: " + PlayerPrefs.HasKey (Ability.Name));
			if (PlayerPrefs.HasKey (Ability.Name)) {
				GameObject newAbility;
				newAbility = Instantiate (AbilityPrefab, AbilitysPanel);
				newAbility.GetComponent<ScriptAbility> ().SetAbilityName (Ability.Name);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddAbility (string Name) {
		PlayerPrefs.SetInt (Name, 1);
	}

	[System.Serializable]
	public class TempAbility {
		public string Name;
	}
}
