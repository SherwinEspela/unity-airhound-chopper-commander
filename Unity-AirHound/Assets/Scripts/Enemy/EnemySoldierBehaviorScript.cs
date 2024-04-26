using UnityEngine;
using System.Collections;

public class EnemySoldierBehaviorScript : MonoBehaviour {
	
	public AnimationClip runClip;
	public AnimationClip fireClip;
	
	void Fire()
	{
		GetComponent<Animation>().Play(fireClip.name);
	}
	
	void Run()
	{
		GetComponent<Animation>().Play(runClip.name);
	}
}
