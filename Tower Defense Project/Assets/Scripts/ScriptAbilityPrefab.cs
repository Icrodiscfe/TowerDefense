using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class ScriptAbilityPrefab : ScriptAbility {
	[SerializeField]
	TMP_Text AbilityName = null;
	[SerializeField]
	TMP_Text AbilityLevel = null;
	[SerializeField]
	TMP_Text AbilityExpBoost = null;
	[SerializeField]
	TMP_Text AbilityNextLevelTimeSpan = null;
	[SerializeField]
	Slider AbilityProgressBar = null;
	[SerializeField]
	Button AbilityButtonLevelUp = null;

	public override void Update () {
		base.Update ();

		if (Data == null)
			return;

		if (Data.Level == 0)
			Destroy (this.gameObject);
		
		//Ability.Update ();
		AbilityName.text = Data.Name;
		AbilityLevel.text = Data.Level.ToString ();
		AbilityExpBoost.text = Data.ExpBoost.ToString ();
		AbilityNextLevelTimeSpan.text = Data.GetnextLevelTimeSpanString();
		AbilityProgressBar.value = Data.GetLevelProgress ();

		if (Data.ReadyForLevelUp) {
			AbilityButtonLevelUp.gameObject.SetActive (true);
			this.transform.GetComponent<RectTransform> ().SetAsFirstSibling ();
		} else
			AbilityButtonLevelUp.gameObject.SetActive(false);
	}

	public void ButtonLevelUp () {
		Data.LevelUp ();
	}

	public void SetAbility (ScriptableObjectAbility _ability) {
		Data = _ability;
	}



	float LevelProgress (DateTime _startDateTime, DateTime _endDateTime, TimeSpan _remainingTimeSpan) {
		TimeSpan totalTimeSpan = _endDateTime - _startDateTime;
		long total = totalTimeSpan.Ticks;
		long current = _remainingTimeSpan.Ticks;
		return Mathf.InverseLerp (total, 0, current);
	}
}