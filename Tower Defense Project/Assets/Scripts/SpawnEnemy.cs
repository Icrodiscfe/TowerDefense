using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Script has to be assigned to the creating button

public class SpawnEnemy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	public GameObject ObjectToBeSpawned, ObjectSpawnLocation;
	public Text TextCosts, TextIncome;
	public int Costs, Income;

	public float TimeMaxSpawn, TimeMaxSpawnInterval;

	GameControl gameControl;
	bool pointerDown, maxSpawn;
	float timerMaxSpawn, timerMaxSpawnInterval;

	void Start () {
		gameControl = GameObject.Find ("GameController").GetComponent<GameControl> ();
		timerMaxSpawn = TimeMaxSpawn;
	}

	void Update () {
		TextCosts.text = Costs.ToString();
		TextIncome.text = "+" + Income.ToString();
		this.GetComponent<Button> ().interactable = gameControl.Gold >= Costs;

		if (timerMaxSpawn <= 0) {
			if (timerMaxSpawnInterval <= 0) {
				timerMaxSpawnInterval = TimeMaxSpawnInterval;
				SpawnUnit ();
			}
			timerMaxSpawnInterval -= Time.deltaTime;
		}
		if (pointerDown)
			timerMaxSpawn -= Time.deltaTime;
	}

	public void OnPointerDown (PointerEventData data) {
		Debug.Log ("OnPointerDown");
		pointerDown = true;
	}

	public void OnPointerUp (PointerEventData data) {
		Debug.Log ("OnPointerUp");
		timerMaxSpawn = TimeMaxSpawn;
		pointerDown = false;
		SpawnUnit ();
	}

	void SpawnUnit () {
		if (this.GetComponent<Button> ().interactable) {
			Transform startTransform = ObjectSpawnLocation.transform;
			Vector3 spawnPosition = new Vector3 (
				Random.Range (-ObjectSpawnLocation.transform.lossyScale.x / 2, ObjectSpawnLocation.transform.lossyScale.x / 2), 
				startTransform.position.y, startTransform.position.z);
			Instantiate (ObjectToBeSpawned, spawnPosition, startTransform.rotation);
			gameControl.Gold -= Costs;
			gameControl.Income += Income;
		}
	}
}
