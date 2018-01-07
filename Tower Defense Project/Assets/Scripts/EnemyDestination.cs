using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour {

	GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.Find ("GameController").GetComponent<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collision) {
		Debug.Log ("collsi");
		Destroy (collision.gameObject);
		gameControl.SubLive (1);
	}
}
