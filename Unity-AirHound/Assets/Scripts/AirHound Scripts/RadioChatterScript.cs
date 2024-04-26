using UnityEngine;
using System.Collections;

public class RadioChatterScript : MonoBehaviour {

	public AudioClip[] radioChatters;
	public AudioClip[] chopperDownChatters;
	public AudioClip[] vitalCriticalChatters;
	public AudioClip[] nukeSecuredChatters; 
	public AudioClip[] nukeFoundChatters; 
	public AudioClip[] noMoreRocketsChatters; 
	public AudioClip only2MinutesLeft; 
	public AudioClip only30SecondsLeft; 
	public AudioClip ohYeah; 
	public AudioClip[] noGoodChatters; 
	public AudioClip[] timeIsRunningOutChatters; 
	public AudioClip siren; 
	public AudioClip[] missionSuccessfulMusic; 

	public static int noRocketsTapCounter = 2; 

	private bool isAllowedToPlay; 
	private float audioRate = 3f; 
	private float nextAudioPlay;
	
	void Start()
	{
		isAllowedToPlay = true; 
	}
	
	void CheckAudioAvailability()
	{
		if (Time.time > nextAudioPlay) {
			isAllowedToPlay = true; 
			nextAudioPlay = Time.time + audioRate;
		}
	}
	
	void InvokePlayRadiochatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playRadioChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokePlayChopperDownChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playChopperDownChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokePlayNukeSecuredChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playNukeSecuredChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokePlayNukeFoundChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playNukeFoundChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokeNoMoreRocketsChatter()
	{
		Invoke("playNoMoreRocketsChatter",1);
	}
	
	void InvokeOnly2MinutesLeftChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playOnly2MinutesLeftChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokeOnly30SecondsLeftChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playOnly30SecondsLeftChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokeOhYeahChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playOhYeahChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokeNoGoodChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playNoGoodChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokeTimeIsRunningOutChatter()
	{
		CheckAudioAvailability();
		if (isAllowedToPlay) {
			Invoke("playTimeIsRunningOutChatter",1);
			isAllowedToPlay = false; 
		}
	}
	
	void InvokePlaySiren()
	{
		Invoke("playSiren",1);
	}
	
	public void InvokePlayMissionSuccessful()
	{
		Invoke("playMissionSuccessfulMusic",2);
	}
	
	void playRadioChatter()
	{
		AudioClip radioChatter = radioChatters[Random.Range(0,radioChatters.Length)];
		//audio.volume = 0.8f; 
		GetComponent<AudioSource>().PlayOneShot(radioChatter); 
	}
	
	void playChopperDownChatter()
	{
		AudioClip chopperDownChatter = chopperDownChatters[Random.Range(0,chopperDownChatters.Length)];
		//audio.volume = 0.8f; 
		GetComponent<AudioSource>().PlayOneShot(chopperDownChatter); 
	}
	
	void playVitalCriticalChatter()
	{
		AudioClip vitalCriticalChatter = vitalCriticalChatters[Random.Range(0,vitalCriticalChatters.Length)];
		//audio.volume = 0.8f; 
		GetComponent<AudioSource>().PlayOneShot(vitalCriticalChatter); 
	}
	
	void playNukeSecuredChatter()
	{
		AudioClip nukeSecuredChatter = nukeSecuredChatters[Random.Range(0,nukeSecuredChatters.Length)];
		GetComponent<AudioSource>().PlayOneShot(nukeSecuredChatter);
	}
	
	void playNukeFoundChatter()
	{
		AudioClip chatter = nukeFoundChatters[Random.Range(0,nukeFoundChatters.Length)];
		GetComponent<AudioSource>().PlayOneShot(chatter);
	}
	
	void playNoMoreRocketsChatter()
	{
		AudioClip chatter = noMoreRocketsChatters[Random.Range(0,noMoreRocketsChatters.Length)];
		GetComponent<AudioSource>().PlayOneShot(chatter);
	}
	
	void playOnly2MinutesLeftChatter()
	{
		GetComponent<AudioSource>().PlayOneShot(only2MinutesLeft); 
	}
	
	void playOnly30SecondsLeftChatter()
	{
		GetComponent<AudioSource>().PlayOneShot(only30SecondsLeft); 
	}
	
	void playOhYeahChatter()
	{
		GetComponent<AudioSource>().PlayOneShot(ohYeah); 
	}
	
	void playNoGoodChatter()
	{
		AudioClip chatter = noGoodChatters[Random.Range(0,noGoodChatters.Length)];
		GetComponent<AudioSource>().PlayOneShot(chatter);
	}
	
	void playTimeIsRunningOutChatter()
	{
		AudioClip chatter = timeIsRunningOutChatters[Random.Range(0,timeIsRunningOutChatters.Length)];
		GetComponent<AudioSource>().PlayOneShot(chatter);
	}
	
	void playSiren()
	{
		GetComponent<AudioSource>().PlayOneShot(siren); 
	}
	
	void playMissionSuccessfulMusic()
	{
		AudioClip music = missionSuccessfulMusic[Random.Range(0,missionSuccessfulMusic.Length)]; 
		GetComponent<AudioSource>().PlayOneShot(music);
	}
}
