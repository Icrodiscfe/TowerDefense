using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptButtonChangeScene : MonoBehaviour, IPointerUpHandler {

	public string sceneName;

	public void OnPointerUp (PointerEventData data) {

		SceneManager.LoadScene (sceneName);

	}
}