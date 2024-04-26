using UnityEngine;
using System.Collections;

public class VitalCriticalWarningAudioScript : MonoBehaviour {
	
	public void playVitalCriticalWarningAudio()
	{
		GetComponent<AudioSource>().Play(); 	
	}
	
	public void stopVitalCriticalWarningAudio()
	{
		GetComponent<AudioSource>().Stop();  	
	}
}
