using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CameraTessing", menuName = "ScriptabeObjects/Camera Setting")]
public class ScriptableObjectCameraControl : ScriptableObject {

	[Header("Zoom")]
	public float ZoomSpeed;
	public float maxZoomIn;
	public float maxZoomOut;

	[Header("Rotation")]
	public float RotateSpeed;
	public float maxRotateUp;
	public float maxRotateDown;
}
