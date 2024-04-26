using UnityEngine;
using System.Collections;

public class ChopperAudioPlayerScript : MonoBehaviour {

	public AnimationClip chopperAudioClip; 
	
	void Start()
	{
		InvokeChopperAudioFadeIn();
	}
	
	void InvokeChopperAudioFadeIn()
	{
		Invoke("ChopperAudioFadeIn",3);
	}
	
	void ChopperAudioFadeIn()
	{
		GetComponent<Animation>().Play(chopperAudioClip.name);
	}
}
