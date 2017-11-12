using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {
	
	public float ZoomSpeed = 2.0f;
	public float HorizontalSpeed = 100.0F;
	public float VerticalSpeed = 100.0F;

	// Update is called once per frame
	void Update () {

		float mouseScrollWheel = Input.GetAxis ("Mouse ScrollWheel");

		Camera.main.transform.Translate (0f, 0f, mouseScrollWheel * ZoomSpeed);

		Cursor.lockState = CursorLockMode.None;

		if(Input.GetKey(KeyCode.Mouse1)){
			Cursor.lockState = CursorLockMode.Locked;
			transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * HorizontalSpeed * Time.deltaTime);
			transform.RotateAround(transform.position, transform.right, -Input.GetAxis("Mouse Y") * VerticalSpeed * Time.deltaTime);
		}
	}
}
