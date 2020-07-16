using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{

	[SerializeField] GameObject deathPrefab;
	SphereCollider sphereCollider;

    void Start() {
        sphereCollider = GetComponent<SphereCollider>();
        
    }

    void Update()
    {

		int playerLayer = 1 << 9;
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.rotation * sphereCollider.center, sphereCollider.radius, playerLayer);
		foreach (Collider collider in colliders) {
			GlobalEventHandler.instance.PlayerDeath();
			GetComponent<EntityEventHandler>().Hit();
			Instantiate(deathPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

        transform.position += Vector3.up * SpeedManager.instance.speed * Time.deltaTime;
    }
}
