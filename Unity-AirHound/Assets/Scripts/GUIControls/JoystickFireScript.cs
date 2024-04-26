using UnityEngine;
using System.Collections;

public class JoystickFireScript : MonoBehaviour {

	private EasyJoystick joystickFireScript; 
	private Transform chopperGunTransform; 
	private Transform chopperRocketLauncherTransform; 

	private float maxRotateX = 50f; 
	private float minRotateX = -20f;

	private float rotateXValue = 0; 

	// Use this for initialization
	void Start () {
		joystickFireScript = GameObject.Find("joystickFire").GetComponent<EasyJoystick>(); 
		chopperGunTransform = GameObject.Find("chopperGun").transform;
		chopperRocketLauncherTransform = GameObject.Find ("chopperRocketLauncher").transform; 
	}
	
	// Update is called once per frame
	void Update () { 
		if (joystickFireScript.JoystickAxis.y > 0) {
			rotateXValue = joystickFireScript.JoystickAxis.y * minRotateX;
		}
		else if (joystickFireScript.JoystickAxis.y < 0) { 
			rotateXValue = joystickFireScript.JoystickAxis.y * maxRotateX / -1f;
		} 

		chopperGunTransform.localEulerAngles = new Vector3(rotateXValue,0,0);
		chopperRocketLauncherTransform.localEulerAngles = new Vector3(rotateXValue,0,0);
	}
}
