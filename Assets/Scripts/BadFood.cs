using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFood : MonoBehaviour {
    
	[SerializeField] int value = 1;
	[SerializeField] GameObject deathPrefab;

	SphereCollider sphereCollider;

    void Start() {
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update() {
		int playerLayer = 1 << 9;
        Collider[] colliders = Physics.OverlapSphere(transform.position + sphereCollider.center, sphereCollider.radius, playerLayer);
		foreach (Collider sphereCollider in colliders) {
			GlobalEventHandler.instance.ScoreChange(value);
			GetComponent<EntityEventHandler>().Hit();
			Instantiate(deathPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		transform.position += Vector3.up * SpeedManager.instance.speed * Time.deltaTime;
    }

	// void OnCollisionEnter(Collision other) {
		
	// 	if (other.gameObject.layer == playerLayer) {
	// 		GlobalEventHandler.instance.ScoreChange(value);
	// 		Destroy(gameObject);
	// 	}
	// }

	void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(transform.position, .5f);
	}
}
