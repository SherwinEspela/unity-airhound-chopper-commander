using UnityEngine;
using System.Collections;

public class ChopperRailGunLookAtScript : MonoBehaviour {
	
	public Transform railGunTarget;
	
	void Update () {
		transform.LookAt(railGunTarget); 
	}
}
