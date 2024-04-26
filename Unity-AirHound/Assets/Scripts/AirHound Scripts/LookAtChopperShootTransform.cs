using UnityEngine;
using System.Collections;

public class LookAtChopperShootTransform : MonoBehaviour {
	
	private GameObject targetObject;
	
	void Awake()
	{
		targetObject = GameObject.Find("chopper_healthCollider");
	}
	
	// Update is called once per frame
	void Update () {
		if (targetObject) {
			this.transform.LookAt(targetObject.transform);	
		}
	}
}
