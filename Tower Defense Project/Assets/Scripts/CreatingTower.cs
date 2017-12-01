using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Script has to be assigned to the creating button

public class CreatingTower : MonoBehaviour, IPointerDownHandler {

	public GameObject 	ObjectToBeCreated;	// Object prefab to be created after button press

	GameObject preObject, createdObject;

	bool creatingActive;
	int counter;

	public void OnPointerDown (PointerEventData data) {
		creatingActive = true;
		preObject = Instantiate (ObjectToBeCreated);
		preObject.name += "_preObject";
		preObject.SetActive (false);
		preObject.GetComponent<TowerMechanic> ().CreatingModeActive = true;
	}

	void Update() {
		if (creatingActive) {
			if (!EventSystem.current.IsPointerOverGameObject ()) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 9999, LayerMask.NameToLayer ("Enviroment"))) {
					preObject.transform.position = hit.point;
					preObject.SetActive (true);
				} else {
					preObject.SetActive (false);
				}

				// Left mouse-klick, Build!
				if (Input.GetKeyDown (KeyCode.Mouse0) && preObject.GetComponent<TowerMechanic> ().CreatingAllowed) {
					counter++;
					createdObject = Instantiate (ObjectToBeCreated, preObject.transform.position, preObject.transform.rotation);
					createdObject.name += counter.ToString();
					createdObject = null;
				}

				// Right mouse-klick, Abbort!
				if (Input.GetKey (KeyCode.Mouse1)) {
					if (createdObject != null)
						Destroy (createdObject);
					if (preObject != null)
						Destroy (preObject);
					creatingActive = false;
				}
			}
		}
	}

	void Build() {

	}


	// Beim drücken auf den button wird der baumodus aktiviert
	// Das Object wird generiert und inaktiv geschaltet

	// bei aktivem baumodus wird auf einen raycasthit gewartet -> Muasposition im gelände
	// bei einem raycasthit wird das zu bauende object an entsprechende mausposition transformiert und aktiv geschaltet

	// Towerscript muss um eine collisionserkennung erweitert werden, der bei kollision den turm rot färbt und ein "bauen nicht möglich" flag setzt.

	// Bei klicken der linken maustaste wird der Turm an entsprechender position platziert



	// sonst:
	// Turm mechaniken mpssen während bauphase inaktiv sein.

	//	LayerMask.GetMask ("Environment")
}
