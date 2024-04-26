using UnityEngine;
using System.Collections;

public class DestroyByCollisionScript : MonoBehaviour {

	// private
	private float damageAmount = 110f;
	private GameObject chopperHealth; 

	// public
	public Transform healthCollider;

	void Awake()
	{
		if (chopperHealth == null) {
			chopperHealth = GameObject.Find("chopper_healthCollider");
		}
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if(chopperHealth != null){
				chopperHealth.SendMessage(
					"DamageChopperByCollision",damageAmount,SendMessageOptions.DontRequireReceiver
				);
			}
			healthCollider.SendMessage("DamageByCollision",SendMessageOptions.DontRequireReceiver);
		}
	}
}
