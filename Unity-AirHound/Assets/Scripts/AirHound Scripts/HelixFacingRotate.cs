using UnityEngine;
using System.Collections;

public class HelixFacingRotate : MonoBehaviour {

	public AnimationClip turnHelixRightClip;
	public AnimationClip turnHelixLeftClip;
	
	public void TurnHelixRight()
	{
		GetComponent<Animation>().Play(turnHelixRightClip.name);
	}
	
	public void TurnHelixLeft()
	{
		GetComponent<Animation>().Play(turnHelixLeftClip.name);
	}
	
}
