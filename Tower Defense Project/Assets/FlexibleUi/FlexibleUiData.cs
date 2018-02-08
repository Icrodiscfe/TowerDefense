using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New UI Style", menuName = "ScriptabeObjects/Flexible UI Data")]
public class FlexibleUiData : ScriptableObject {

	[Header("Button")]
	public Color buttonNormalColor; 
	public Color buttonHighlightedColor;
	public Color buttonPressedColor; 
	public Color buttonDisabledColor; 
	public Color buttonTextColor;

	[Header("InputField")]
	public Color inputFieldNormalColor;
	public Color inputFieldHighlightedColor; 
	public Color inputFieldTextColor;

	[Header("Panel")]
	public Color panelColor;
}
