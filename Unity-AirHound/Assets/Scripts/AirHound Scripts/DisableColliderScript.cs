using UnityEngine;
using System.Collections;

public class DisableColliderScript : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		Invoke("DisableCollider",2f); 
	}
	
	void DisableCollider()
	{
		transform.GetComponent<Collider>().enabled = false;
	}
}
