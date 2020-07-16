using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	
	Vector3 originalLocalPos;

    void Awake() {
		originalLocalPos = transform.localPosition;
	}

	IEnumerator ShakeNoise(float duration, float intensity, float speed) {
		float start = UnityEngine.Random.Range(0f, 100f);
		for (float time = 0f; time < duration; time += Time.deltaTime) {
			transform.localPosition += new Vector3(
				Mathf.PerlinNoise(start + time * speed, start)-.5f,
				Mathf.PerlinNoise(start, start + time * speed)-.5f,
				0f
			) * intensity * (1f - time / duration);
			yield return null;
		}
	}

	public void AddShakeNoise(float duration, float intensity, float speed) {
		StartCoroutine(ShakeNoise(duration, intensity, speed));
	}

	float HermiteInterpolation(float edge0, float edge1, float x) {
		float t = Mathf.Clamp01((x - edge0) / (edge1 - edge0));
		return t * t * (3f - 2f * t);
	}

	IEnumerator ShakeDirectional(float duration, Vector2 direction, float speed) {
		for (float time = 0f; time < duration; time += Time.deltaTime) {
			float wave = Mathf.Cos(time * (speed - 1f) * Mathf.PI * .5f);
			float dampening = HermiteInterpolation(duration, 0f, time);
			transform.localPosition += (Vector3)direction * wave * dampening;
			yield return null;
		}
	}

	public void AddShakeDirectional(float duration, Vector2 direction, float speed) {
		StartCoroutine(ShakeDirectional(duration, direction, speed));
	}

	void Update() {
		transform.localPosition = originalLocalPos;

	} 	
}