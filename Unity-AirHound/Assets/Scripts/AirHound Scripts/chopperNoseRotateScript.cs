using UnityEngine;
using System.Collections;

public class chopperNoseRotateScript : MonoBehaviour {
	
	public AnimationClip noseDownClip;
	public AnimationClip noseUpClip;

	public GameObject joystickLeft; 
	private EasyJoystick easyJoystickScript; 

	private bool chopperIsFacingFront = true; 

	void Start () {
		easyJoystickScript = joystickLeft.GetComponent<EasyJoystick>(); 
	}
	
	void On_JoystickMove( MovingJoystick move)
	{
		if (chopperIsFacingFront && easyJoystickScript.JoystickAxis.x > 0.8f) {
			if (transform.rotation.eulerAngles.z <= 0f) {
				GetComponent<Animation>().Play(noseDownClip.name);
			}	
		}

		else if (!chopperIsFacingFront && easyJoystickScript.JoystickAxis.x < -0.8f) {
			if (transform.rotation.eulerAngles.z <= 0f) {
				GetComponent<Animation>().Play(noseDownClip.name);
			}
		}
	}

	void On_JoystickMoveEnd( MovingJoystick move) 
	{
		if (transform.rotation.eulerAngles.z >= 348f) {
			GetComponent<Animation>().Play(noseUpClip.name);
		}

	}

	public void ChopperIsFacingFront()
	{
		chopperIsFacingFront = true; 
	}
	
	public void ChopperIsFacingBack()
	{
		chopperIsFacingFront = false; 
	}
}
