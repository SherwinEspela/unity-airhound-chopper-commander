using UnityEngine;
using System.Collections;

public class LookAtScriptYConstraint : MonoBehaviour {

	private GameObject targetObject;
	private Transform target;
	public float yOffsetValue; 
	
	void Awake()
	{
		targetObject = GameObject.Find("chopper_healthCollider");
		if (targetObject) {
			target = targetObject.transform; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 targetPosition = new Vector3(target.position.x,yOffsetValue,target.position.z);
			transform.LookAt(targetPosition);	
		}
	}
}
