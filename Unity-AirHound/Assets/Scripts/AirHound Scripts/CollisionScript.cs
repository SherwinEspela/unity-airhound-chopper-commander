using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		Debug.Log(hit.moveDirection);
//		if (hit.moveDirection.y > 0.01) {
//			return;
//		}
			
	}
}
