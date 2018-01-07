using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public string PlayerName;
	public int Lives, Gold, Income;
	public float TimeIncome, TimerIncome;


	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {
		TimerIncome = TimeIncome;
	}


	void Update () {
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
