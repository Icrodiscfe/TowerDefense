using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptAbility : MonoBehaviour {

	public ScriptableObjectAbility Data;

	public virtual void Start () {
		Data.Start ();
	}

	public virtual void Update () {
		Data.Update ();
	}
}
