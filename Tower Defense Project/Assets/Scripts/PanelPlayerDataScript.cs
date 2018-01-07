using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlayerDataScript : MonoBehaviour {

	public Text TextLives, TextGold, TextIncome, TextNextIncome;

	GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.Find ("GameController").GetComponent<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		TextLives.text = gameControl.Lives.ToString ();
		TextGold.text = gameControl.Gold.ToString ();
		TextIncome.text = gameControl.Income.ToString ();
		TextNextIncome.text = gameControl.TimerIncome.ToString ("##.000");
	}
}
