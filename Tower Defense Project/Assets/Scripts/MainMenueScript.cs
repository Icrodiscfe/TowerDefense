using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenueScript : MonoBehaviour {

	[Header("Settings")]
	public InputField InputPlayerName;

	GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.Find ("GameController").GetComponent<GameControl> ();
		if (gameControl.PlayerName != null)
			InputPlayerName.text = gameControl.PlayerName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadSceneByName (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void InputFieldPlayerName (string name) {
		gameControl.PlayerName = name;
	}
}
