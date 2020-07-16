using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDelay : MonoBehaviour {
    [SerializeField] Transform target;

	Vector3 localPosition;
	Vector3 localEulerAngles;

    void Start() {
        localPosition = transform.localPosition;
		localEulerAngles = transform.localEulerAngles;
    }


    void Update() {
        transform.position = Vector3.Lerp(transform.position, target.position + transform.localRotation * localPosition, 20f * Time.deltaTime);
		// transform.localEulerAngles = Quaternion.Euler(target.localEulerAngles) * localEulerAngles;
    }
}
