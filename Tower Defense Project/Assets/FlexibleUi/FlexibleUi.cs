using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlexibleUi : MonoBehaviour {

	public FlexibleUiData skinData;

	protected virtual void OnSkinUI () {

	}

	public virtual void Awake () {
		#if UNITY_EDITOR
		if (skinData == null)
			skinData = Resources.Load<FlexibleUiData>("SkinDataDefault") as FlexibleUiData;
		#endif
		if (skinData != null)
			OnSkinUI ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		#if UNITY_EDITOR
		if (skinData == null)
			skinData = Resources.Load<FlexibleUiData>("SkinDataDefault") as FlexibleUiData;
		if (skinData != null)
			OnSkinUI ();
		#endif
	}

}
