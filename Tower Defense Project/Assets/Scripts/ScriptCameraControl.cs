using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCameraControl : MonoBehaviour {

	public ScriptableObjectCameraControl cameraSettings;
	public Transform target, follower, orbitPoint;

	[Header("ControlButtons")]
	public ScriptButtonState buttonZoomIn;
	public ScriptButtonState buttonZoomOut;
	public ScriptButtonState buttonMoveLeft;
	public ScriptButtonState buttonMoveRight;
	public ScriptButtonState buttonMoveUp;
	public ScriptButtonState buttonMoveDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Move follower to target pos with offset
		follower.position = target.position + new Vector3(0, 1, 0);

		//Rotate OrbitPoint to Camera
		Transform targetTransform = transform;
		targetTransform.LookAt (target);
		Quaternion targetRotation = targetTransform.rotation;
		Vector3 rotation = Quaternion.RotateTowards(orbitPoint.rotation, targetRotation, 360).eulerAngles;
		orbitPoint.rotation = Quaternion.Euler (0f, rotation.y, 0f);


	}

	void LateUpdate () {
		transform.LookAt(orbitPoint);

		Vector3 currentZoom = transform.position - target.position;

		if ((buttonZoomIn.isPressed) & (currentZoom.magnitude > cameraSettings.maxZoomIn))
			transform.Translate(transform.forward * cameraSettings.ZoomSpeed * Time.deltaTime, Space.World);
		
		if ((buttonZoomOut.isPressed) & (currentZoom.magnitude < cameraSettings.maxZoomOut))
			transform.Translate(-transform.forward * cameraSettings.ZoomSpeed * Time.deltaTime, Space.World);

		Vector3 targetDir = target.position - transform.position;
		float cameraangle = Vector3.Angle (orbitPoint.forward, transform.forward);

		if ((buttonMoveUp.isPressed) & (cameraangle < cameraSettings.maxRotateUp))
			transform.RotateAround (orbitPoint.position, orbitPoint.right, cameraSettings.RotateSpeed * Time.deltaTime);
		if ((buttonMoveDown.isPressed) & (cameraangle > cameraSettings.maxRotateDown))
			transform.RotateAround (orbitPoint.position, orbitPoint.right, -cameraSettings.RotateSpeed * Time.deltaTime);

		if ((buttonMoveRight.isPressed))
			transform.RotateAround (orbitPoint.position, orbitPoint.up, cameraSettings.RotateSpeed * Time.deltaTime);
		if ((buttonMoveLeft.isPressed))
			transform.RotateAround (orbitPoint.position, orbitPoint.up, -cameraSettings.RotateSpeed * Time.deltaTime);
	}
}
