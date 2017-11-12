using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float Speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * Time.deltaTime * Speed);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * Time.deltaTime * Speed);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back * Time.deltaTime * Speed);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(Vector3.right * Time.deltaTime * Speed);
		}
	}
}
