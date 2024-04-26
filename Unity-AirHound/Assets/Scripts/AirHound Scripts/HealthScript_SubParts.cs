using UnityEngine;
using System.Collections;

public class HealthScript_SubParts : MonoBehaviour {
	
	public GameObject objectWithHealthScript;
	public int bulletDamage = 1;
	public int rocketDamage = 10;
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name.Contains("chopperBullet")) {
			objectWithHealthScript.SendMessage("DecreaseObjectsHealth",bulletDamage,SendMessageOptions.DontRequireReceiver);
		}
		
		else if (col.gameObject.name.Contains("rocket")) {
			objectWithHealthScript.SendMessage("DecreaseObjectsHealth",rocketDamage,SendMessageOptions.DontRequireReceiver);
		}
	}
}
