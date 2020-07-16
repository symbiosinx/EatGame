using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventHandler : MonoBehaviour {

	public static GlobalEventHandler instance;
    void Awake() { instance = this; }


	public Action OnPlayerDeath;
	public Action<int> OnScoreChange;


	public void PlayerDeath() {
		OnPlayerDeath?.Invoke();
	}
	public void ScoreChange(int change) {
		OnScoreChange?.Invoke(change);
	}

}
