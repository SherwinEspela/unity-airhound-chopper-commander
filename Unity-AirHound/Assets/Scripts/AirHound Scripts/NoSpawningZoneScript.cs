using UnityEngine;
using System.Collections;

public class NoSpawningZoneScript : MonoBehaviour {
	
	public AudioClip sirenAudio;
	private bool sirenPlayed = false;

	public delegate void NoSpawnZoneEnterAction();
	public static event NoSpawnZoneEnterAction OnNoSpawnZoneEnter;
	public static event NoSpawnZoneEnterAction OnNoSpawnZoneExit;
	
	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if (OnNoSpawnZoneEnter != null) {
				OnNoSpawnZoneEnter ();
			}
		} 
	}
	
	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if (OnNoSpawnZoneExit != null) {
				OnNoSpawnZoneExit ();
			}
				
			if (sirenAudio) {
				if (!sirenPlayed) {
					GetComponent<AudioSource>().PlayOneShot(sirenAudio);
					sirenPlayed = true;  
				}
			}
		} 
	}
}
