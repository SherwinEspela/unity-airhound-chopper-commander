using UnityEngine;
using System.Collections;

public class WheelRotation : MonoBehaviour {

	public float rotateSpeed; 
	public float smooth; 
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(Time.deltaTime * rotateSpeed * smooth,0,0));
	}
}
