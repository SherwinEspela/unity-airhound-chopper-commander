using UnityEngine;
using System.Collections;

public class enemySoundFXScript : MonoBehaviour {
	
	public AudioClip enemyDestroyedAudio; 
	
	void playEnemyDestroyedExplosionAudio()
	{
		if (GetComponent<AudioSource>()) {
			GetComponent<AudioSource>().PlayOneShot(enemyDestroyedAudio); 
		}
	}
}
