using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Script has to be assigned to the creating button

public class SpawnEnemy : MonoBehaviour, IPointerDownHandler {
	
	public GameObject ObjectToBeSpawned, ObjectSpawnLocation;
	public Text TextCosts, TextIncome;
	public int Costs, Income;

	GameControl gameControl;

	void Start () {
		gameControl = GameObject.Find ("GameControler").GetComponent<GameControl> ();
	}

	void Update () {
		TextCosts.text = Costs.ToString();
		TextIncome.text = "+" + Income.ToString();
		this.GetComponent<Button> ().interactable = gameControl.Gold >= Costs;
	}

	public void OnPointerDown (PointerEventData data) {
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
