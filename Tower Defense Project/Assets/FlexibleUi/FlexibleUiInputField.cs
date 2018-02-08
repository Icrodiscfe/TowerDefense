using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class FlexibleUiInputField : FlexibleUi {
	
	protected override void OnSkinUI () {
		base.OnSkinUI ();

		var colors = GetComponent<TMP_InputField> ().colors;
		colors.normalColor = skinData.inputFieldNormalColor;
		colors.highlightedColor = skinData.inputFieldHighlightedColor;
		GetComponent<TMP_InputField> ().colors = colors;

		GetComponent<TMP_InputField> ().textComponent.color = skinData.inputFieldTextColor;
	}
}
