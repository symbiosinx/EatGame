using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFoodSpawner : MonoBehaviour {

	float spawnSpeed = 1f;

	[SerializeField] GameObject[] badFoods;
	float timer = 0f;

    void Start() {
        
    }

    void Update() {
        timer += Time.deltaTime;
		if (timer > spawnSpeed) {
			timer = 0f;

			int randomIndex = Random.Range(0, badFoods.Length);
			GameObject randomBadFood = badFoods[randomIndex];
			float randomAngle = (float)Random.Range(0, 5)*360f/5f;
			Instantiate(randomBadFood, new Vector3(0f, -40, 0f), Quaternion.Euler(0f, randomAngle, 0f));

			spawnSpeed = (1f / SpeedManager.instance.speed) * 20f + Random.Range(-.25f, .5f);

		}
    }
}
