using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyFPSCounter : MonoBehaviour {

	public float FrameRate;
	public Text TextFrameRate;
	// Use this for initialization
	void Start () {
		
	}

	float FrameCountTimer, FrameCounter;
	// Update is called once per frame
	void Update () {
		FrameCountTimer += Time.deltaTime;
		FrameCounter++;
		if (FrameCountTimer >= 1) {
			FrameRate = FrameCounter;
			TextFrameRate.text = FrameRate.ToString ();
			FrameCounter = 0;
			FrameCountTimer = 0;
		}
	}
}
