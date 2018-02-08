using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Ability", menuName = "ScriptabeObjects/Ability")]
public class ScriptableObjectAbility : ScriptableObject {

	public string Name;
	public int BaseExp = 60;
	public float RaiseExpRate = 2;
	public int Level = 0;
	public int ExpBoost = 1;


	public string NextLevelDateTimeString;
	public string LastLevelDateTimeString;
	public bool ReadyForLevelUp;

	long NextLevelExp;
	DateTime NextLevelDateTime;
	DateTime LastLevelDateTime;
	TimeSpan NextLevelTimeSpan;

	public void Start () {
		if (Level == 0)
			return;
		NextLevelDateTime = DateTime.Parse (NextLevelDateTimeString);
		LastLevelDateTime = DateTime.Parse (LastLevelDateTimeString);
	}

	public void Update () {
		if (Level == 0)
			return;
		NextLevelTimeSpan = NextLevelDateTime - DateTime.Now;
		ReadyForLevelUp = NextLevelTimeSpan <= TimeSpan.FromTicks (0);
	}

	public void AddAbility () {
		if (Level == 0) {
			Level++;
			NextLevelExp = Mathf.RoundToInt (BaseExp * Mathf.Pow (RaiseExpRate, Level - 1));
			NextLevelDateTime = DateTime.Now.Add (TimeSpan.FromTicks (NextLevelExp * 10000000));
			NextLevelDateTimeString = NextLevelDateTime.ToString ();
			LastLevelDateTime = DateTime.Now;
			LastLevelDateTimeString = LastLevelDateTime.ToString ();
		}
	}
		
	public void LevelUp () {
		if (ReadyForLevelUp) {
			Level ++;
			NextLevelExp = Mathf.RoundToInt (BaseExp * Mathf.Pow (RaiseExpRate, Level - 1));
			NextLevelDateTime = DateTime.Now.Add (TimeSpan.FromTicks (NextLevelExp * 10000000));
			NextLevelDateTimeString = NextLevelDateTime.ToString ();
			LastLevelDateTime = DateTime.Now;
			LastLevelDateTimeString = LastLevelDateTime.ToString ();
		}
	}

	public string GetnextLevelTimeSpanString () {
		string timeSpanString = null;
		if (NextLevelTimeSpan.Days > 0)
			timeSpanString += NextLevelTimeSpan.Days + "d ";
		if (NextLevelTimeSpan.Hours > 0)
			timeSpanString += NextLevelTimeSpan.Hours + "h ";
		if (NextLevelTimeSpan.Minutes > 0)
			timeSpanString += NextLevelTimeSpan.Minutes + "m ";
		if (NextLevelTimeSpan.Seconds > 0)
			timeSpanString += NextLevelTimeSpan.Seconds + "s ";
		return timeSpanString;
	}

	public float GetLevelProgress () {
		TimeSpan totalTimeSpan = NextLevelDateTime - LastLevelDateTime;
		long total = totalTimeSpan.Ticks;
		long current = NextLevelTimeSpan.Ticks;
		return Mathf.InverseLerp (total, 0, current);
	}
}
