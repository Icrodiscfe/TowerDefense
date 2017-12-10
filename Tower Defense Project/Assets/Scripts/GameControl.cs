using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public Text TextLives, TextGold, TextIncome;
	public int Lives, Gold, Income;
	public float TimeIncome;

	float TimerIncome;

	void Start () {
		TimerIncome = TimeIncome;
	}

	void Update () {
		TextLives.text = Lives.ToString ();
		TextGold.text = Gold.ToString ();
		TextIncome.text = Income.ToString ();

		TimerIncome -= Time.deltaTime;
		if (TimerIncome <= 0) {
			Gold += Income;
			TimerIncome = TimeIncome;
		}
	}

	public void SubLive(int _amount) {
		Lives -=_amount;
	}
}
