using UnityEngine;
using System.Collections;

public class JoystickLeftScript : MonoBehaviour {

	private bool chopperIsFacingFront = true;
	private EasyJoystick easyJoystickScript;
	public GameObject railGunProjectileSpawn;
	private Vector3 railGunProjectileSpawnOriginalPosition;
	private Vector3 railGunProjectileSpawnOffsetPosition;
	private float normalSpeed;
	private float backwardSpeed; 

	// Use this for initialization
	void Start () {
		railGunProjectileSpawnOriginalPosition = railGunProjectileSpawn.transform.localPosition; 
		railGunProjectileSpawnOffsetPosition = new Vector3(0.008149326f,-0.1218f,1.158f); 
		easyJoystickScript = gameObject.GetComponent<EasyJoystick>();

		easyJoystickScript.speed.x = 5; 
		easyJoystickScript.speed.y = 5; 

		normalSpeed = easyJoystickScript.speed.x;
		backwardSpeed = normalSpeed / 2; 
	}
	
	// Update is called once per frame
	void Update () {
		if (chopperIsFacingFront && easyJoystickScript.JoystickAxis.x < 0) {
			easyJoystickScript.speed.x = backwardSpeed; 	
		}

		else if (!chopperIsFacingFront && easyJoystickScript.JoystickAxis.x > 0) {
			easyJoystickScript.speed.x = backwardSpeed;
		}

		else {
			easyJoystickScript.speed.x = normalSpeed; 
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

	void AdjustRailGunProjectileSpawnPosition()
	{
		if (easyJoystickScript.JoystickAxis.x > 0.8 || easyJoystickScript.JoystickAxis.x < -0.8) {
			railGunProjectileSpawn.transform.localPosition = railGunProjectileSpawnOffsetPosition; 		
		} else {
			railGunProjectileSpawn.transform.localPosition = railGunProjectileSpawnOriginalPosition; 
		}
	}
}
