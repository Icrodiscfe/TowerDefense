using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class FlexibleUiPanel : FlexibleUi {

	protected override void OnSkinUI () {
		base.OnSkinUI ();

		GetComponent<Image> ().color = skinData.panelColor;
	}
}
