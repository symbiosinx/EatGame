using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityEventHandler))]
public class EntityCameraShaker : MonoBehaviour {

	EntityEventHandler eventHandler;
	CameraShake cameraShake;

	void Awake() {
		eventHandler = GetComponent<EntityEventHandler>();
	}

    void Start() {
		Debug.LogWarning("Using Camera.main");
        cameraShake = Camera.main.GetComponent<CameraShake>();

		eventHandler.OnHit += () => {
			cameraShake.AddShakeNoise(.1f, .5f, 5f);
		};
		eventHandler.OnDeath += () => {
			cameraShake.AddShakeNoise(.15f, .5f, 2.5f);
		};
    }
}
