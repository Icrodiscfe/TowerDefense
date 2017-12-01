using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Script has to be assigned to the creating button

public class SpawnEnemy : MonoBehaviour, IPointerDownHandler {
	
	public GameObject ObjectToBeSpawned, ObjectSpawnLocation;

	public void OnPointerDown (PointerEventData data) {
		Transform startTransform = ObjectSpawnLocation.transform;
		Vector3 spawnPosition = new Vector3 (
			Random.Range (ObjectSpawnLocation.transform.lossyScale.x / 2, ObjectSpawnLocation.transform.lossyScale.x / 2), 
			startTransform.position.y, startTransform.position.z);
		Instantiate (ObjectToBeSpawned, spawnPosition, startTransform.rotation);
	}
}
