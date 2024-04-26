using UnityEngine;
using System.Collections;

public class EnemyMuzzleFlashScript : MonoBehaviour {
	
	public AnimationClip muzzleFlashClip;
	
	void PlayMuzzleFlash()
	{
		GetComponent<Animation>().Play(muzzleFlashClip.name);
	}
}
