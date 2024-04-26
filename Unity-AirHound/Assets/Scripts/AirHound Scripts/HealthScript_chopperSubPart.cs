using UnityEngine;
using System.Collections;

public class HealthScript_chopperSubPart : MonoBehaviour {
	
	public ChopperHealth chopperHealthScript; 

	void OnCollisionEnter (Collision col)
	{
		chopperHealthScript.ReduceChopperHealth (col); 
	}
}
