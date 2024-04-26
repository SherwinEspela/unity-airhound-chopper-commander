using UnityEngine;
using System.Collections;

public class LookAtCube_BoundaryScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
	{
		float zClamp = Mathf.Clamp(transform.localPosition.z,3f,5f); 
		float yClamp = Mathf.Clamp(transform.localPosition.y,-2f,0.2f); 
		transform.localPosition = new Vector3(0, yClamp, zClamp);
	}
}
