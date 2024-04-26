using UnityEngine;
using System.Collections;

public class LookAtScript : MonoBehaviour {
	
	public float rangeMax = 14;
	public float rangeMin = 3;
	
	private GameObject targetObject;
	private Transform target; 
	
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
			if ((Vector3.Distance(transform.position, target.position) < rangeMax) && 
			    ((transform.position.x - target.position.x) > rangeMin) || 
			    ((target.position.x - transform.position.x) > rangeMin)) {	
				transform.LookAt(target);
			}	
		}
	}
}
