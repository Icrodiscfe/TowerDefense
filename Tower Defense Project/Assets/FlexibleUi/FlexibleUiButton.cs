using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class FlexibleUiButton : FlexibleUi {
	
	protected override void OnSkinUI () {
		base.OnSkinUI ();

		var colors = GetComponent<Button> ().colors;
		colors.normalColor = skinData.buttonNormalColor;
		colors.highlightedColor = skinData.buttonHighlightedColor;
		colors.pressedColor = skinData.buttonPressedColor;
		colors.disabledColor = skinData.buttonDisabledColor;

		GetComponent<Button> ().colors = colors;
	}
}
