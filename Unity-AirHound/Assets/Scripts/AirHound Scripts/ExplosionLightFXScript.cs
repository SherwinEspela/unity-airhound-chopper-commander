using UnityEngine;
using System.Collections;

public class ExplosionLightFXScript : MonoBehaviour {

	public AnimationClip explosionFXClip;
	
	void PlayExplosionLightFX()
	{
		Debug.Log("PlayExplosionLightFX method...");
		GetComponent<Animation>().Play(explosionFXClip.name);
	}
}
