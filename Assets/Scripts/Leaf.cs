using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
	[SerializeField] Transform pivot;
	[SerializeField] Transform bodyPivot;

	Vector3 previousRotation;
	Vector3 velocity = Vector3.zero;

    void Start() {
        previousRotation = bodyPivot.localEulerAngles;
    }

    void Update() {
		float angleChange = (bodyPivot.localEulerAngles.y - previousRotation.y) / Time.deltaTime;
		Vector3 localEulerAngles = pivot.localEulerAngles;
		localEulerAngles.y = Mathf.Lerp(localEulerAngles.y, angleChange * .2f, Time.deltaTime * 10f);
		pivot.localEulerAngles = localEulerAngles;

		previousRotation = bodyPivot.localEulerAngles;
    }
}
