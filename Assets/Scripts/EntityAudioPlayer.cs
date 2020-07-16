using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityEventHandler), typeof(AudioSource))]
public class EntityAudioPlayer : MonoBehaviour {
    
	EntityEventHandler eventHandler;
	AudioSource audioSource;
	AudioManager audioManager;

	[SerializeField] AudioClip preAttackClip;
	[SerializeField] AudioClip preAttackEndClip;
	[SerializeField] AudioClip attackClip;
	[SerializeField] AudioClip attackEndClip;
	[SerializeField] AudioClip hitClip;
	[SerializeField] AudioClip deathClip;
	[SerializeField] AudioClip collectClip;
	[SerializeField] AudioClip fallClip;
	[SerializeField] AudioClip landClip;
	[SerializeField] AudioClip specialEventClip;
	[SerializeField] AudioClip specialEventEndClip;

	void Awake() {
		eventHandler = GetComponent<EntityEventHandler>();
		audioSource = GetComponent<AudioSource>();
	}

    void Start() {

		audioManager = AudioManager.instance;
		
		eventHandler.OnPreAttack += () => {
			audioSource.PlayOneShot(preAttackClip);
		};
		eventHandler.OnPreAttackEnd += () => {
			audioSource.PlayOneShot(preAttackEndClip);
		};
		eventHandler.OnAttack += () => {
			audioSource.PlayOneShot(attackClip);
		};
		eventHandler.OnAttackEnd += () => {
			audioSource.PlayOneShot(attackEndClip);
		};
		eventHandler.OnHit += () => {
			audioManager.Play(hitClip);
		};
		eventHandler.OnDeath += () => {
			audioManager.Play(deathClip);
		};
		eventHandler.OnCollect += (int value) => {
			float pitch = Mathf.Log((float)value, 2f)*.25f + .75f;
			audioManager.Play(collectClip, pitch);
		};
		eventHandler.OnFall += () => {
			audioSource.PlayOneShot(fallClip);
		};
		eventHandler.OnLand += () => {
			audioManager.Play(landClip);
		};
		eventHandler.OnSpecialEvent += () => {
			audioSource.PlayOneShot(specialEventClip);
		};
		eventHandler.OnSpecialEventEnd += () => {
			audioSource.PlayOneShot(specialEventEndClip);
		};
    }
}
