using UnityEngine;
using System.Collections;

public class LookAtCube_CollisionScript : MonoBehaviour {
	
	public Transform bullet; 
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "chopperBullet(Clone)") {
			Physics.IgnoreCollision(col.collider, GetComponent<Collider>()); 
		}
//		
//		else if (col.gameObject.name == "rocket(Clone)") {
//			health -= rocketDamage; 
//		}
		
		
	}
}
