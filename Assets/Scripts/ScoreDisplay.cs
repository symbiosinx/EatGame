using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    
	[SerializeField] Text text;
	[SerializeField] Text finalText;

	int score = 0;

    void Start()
    {

		text.text = score.ToString();

        GlobalEventHandler.instance.OnScoreChange += (int change) => {
			StartCoroutine(_CountUp(score + change));
		};
    }

	IEnumerator _CountUp(int newScore) {
		finalText.text = newScore.ToString();

		while (score < newScore) {
			for (int i = 0; i < Random.Range(2, 5); i++) {
				score+=5;
			}
			if (score > newScore) score = newScore;
			text.text = score.ToString();
			yield return null;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
