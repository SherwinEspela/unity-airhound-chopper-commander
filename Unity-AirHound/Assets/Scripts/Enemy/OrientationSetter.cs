using UnityEngine;
using System.Collections;

public class OrientationSetter : MonoBehaviour {

	// Use this for initialization
	void SetOrientation(float rotateYOffset) 
	{
		this.transform.Rotate(new Vector3(0,rotateYOffset,0));
	}
}
