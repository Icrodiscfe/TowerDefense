using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Script has to be assigned to the creating button

public class CreatingTower : MonoBehaviour, IPointerDownHandler {

	public GameObject ObjectToBeCreated;	// Object prefab to be created after button press

	GameObject createdObject;

	bool creatingActive;

	public void OnPointerDown (PointerEventData data) {
		creatingActive = true;
		createdObject = Instantiate (ObjectToBeCreated);
		createdObject.SetActive (false);
	}

	void Update() {
		if (creatingActive) {
			if (!EventSystem.current.IsPointerOverGameObject ()) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 9999, LayerMask.GetMask ("Terrain"))) {
					createdObject.transform.position = hit.point;
					createdObject.SetActive (true);
				} else {
					createdObject.SetActive (false);
				}

				if (Input.GetKey (KeyCode.Mouse0)) {
					createdObject = null;
					creatingActive = false;
				}
			}
		}
	}



	// Beim drücken auf den button wird der baumodus aktiviert
	// Das Object wird generiert und inaktiv geschaltet

	// bei aktivem baumodus wird auf einen raycasthit gewartet -> Muasposition im gelände
	// bei einem raycasthit wird das zu bauende object an entsprechende mausposition transformiert und aktiv geschaltet

	// Towerscript muss um eine collisionserkennung erweitert werden, der bei kollision den turm rot färbt und ein "bauen nicht möglich" flag setzt.

	// Bei klicken der linken maustaste wird der Turm an entsprechender position platziert



	// sonst:
	// Turm mechaniken mpssen während bauphase inaktiv sein.
}
