using UnityEngine;
using System.Collections;

public class FlareRandomBrightness : MonoBehaviour {

	
	private float nextMove;
	public float moveRate = 5f;
	//public AnimationClip flareClip; 
	//public Animator flareAnimator; 
	
	// Update is called once per frame
	void Update () {
		//BrightnessChanging(); 
	}
	
	void BrightnessChanging()
	{
		if (Time.time > nextMove) {

			nextMove = Time.time + moveRate;
		}
	}
}
