using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour {

	[SerializeField] Transform pivot;
	float rails = 5f;
	int currentRail = 0;
	float angle = 0f;

    void Start() {
        
    }

    void Update() {
		// float newAngle = angle;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			currentRail++;
			// newAngle += Time.deltaTime * 5000f;
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
			currentRail--;
			// newAngle -= Time.deltaTime * 5000f;
		}
		Vector3 rotation = pivot.eulerAngles;

		float newAngle = (float)currentRail * 360f / rails;

		angle = Mathf.Lerp(angle, newAngle, Time.deltaTime * 4f);

		rotation.y = angle;
		pivot.eulerAngles = rotation;

    }

	float mod(float x, float m) {
    	return (x%m + m)%m;
	}
	
}
