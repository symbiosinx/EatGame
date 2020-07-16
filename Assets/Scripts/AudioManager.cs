using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField] AudioLowPassFilter lowPassFilter;

	public static AudioManager instance;
	AudioSource audioSource;

	void Awake() {
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}

    public void Play(AudioClip clip, float pitch=1f, float volume=1f) {
		if (pitch == 1f) {
			audioSource.PlayOneShot(clip, volume);
		} else {
			AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
			newAudioSource.pitch = pitch;
			newAudioSource.PlayOneShot(clip, volume);
			Destroy(newAudioSource, clip.length);
		}
	}

	public void MuffleAudio() {
		StartCoroutine(_MuffleAudio());
	}

	IEnumerator _MuffleAudio() {
		lowPassFilter.enabled = true;
		float duration = 2f;
		for (float time = 0f; time < duration; time += Time.deltaTime) {
			lowPassFilter.cutoffFrequency = Mathf.Lerp(3000f, 22000f, time/duration);
			// lowPassFilter.lowpassResonanceQ = Mathf.Lerp(2f, 1f, time/duration);
			yield return null;
		}
		lowPassFilter.enabled = false;
	}
}
