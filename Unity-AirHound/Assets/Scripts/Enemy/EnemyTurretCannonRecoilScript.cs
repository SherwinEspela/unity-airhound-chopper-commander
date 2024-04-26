using UnityEngine;
using System.Collections;

public class EnemyTurretCannonRecoilScript : MonoBehaviour {

	public AnimationClip recoilClip;
	
	void PlayRecoil()
	{
		GetComponent<Animation>().Play(recoilClip.name);
	}
}
