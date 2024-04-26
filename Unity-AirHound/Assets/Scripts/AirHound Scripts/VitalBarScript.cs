using UnityEngine;
using System.Collections;

public class VitalBarScript : MonoBehaviour {
	
	public AnimationClip vitalBarClip;
	
	public void PlayVitalBarAnimation()
	{
		GetComponent<Animation>().Play(vitalBarClip.name);
	}
	
	public void StopVitalBarAnimation()
	{
		GetComponent<Animation>().Stop(vitalBarClip.name); 
	}
}
