using UnityEngine;
using System.Collections;

public class ExplosionFXAudio : MonoBehaviour {

	public AudioClip[] explosionSounds; 

	void Awake()
	{
		if (explosionSounds.Length > 0) {
			AudioClip explosionSound = explosionSounds[Random.Range(0,explosionSounds.Length)];
			GetComponent<AudioSource>().PlayOneShot(explosionSound);	
		}
	}
}
