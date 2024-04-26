using UnityEngine;
using System.Collections;

public class AdjustSFXVolume : MonoBehaviour {

	public float volumeValue = 0.5f; 

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.HasKey("SFXVolume")) {
			if (PlayerPrefs.GetFloat("SFXVolume") >= volumeValue) {
				gameObject.GetComponent<AudioSource>().volume = volumeValue;
			} else {
				gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume"); 
			}
		}
	}
}
