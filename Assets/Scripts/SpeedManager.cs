using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

	public float speed = 10f;
	
	[SerializeField] float increase = .25f;
	[SerializeField] bool shake = true;

    public static SpeedManager instance;

	CameraShake cameraShake;
    void Awake()
    {
        instance = this;
		if (shake) {
			cameraShake = Camera.main.GetComponent<CameraShake>();
			cameraShake.AddShakeNoise(1000000000f, .05f, 4f);
		}
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * increase;
    }
}
