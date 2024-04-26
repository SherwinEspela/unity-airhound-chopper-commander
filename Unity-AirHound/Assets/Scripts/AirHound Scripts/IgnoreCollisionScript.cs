using UnityEngine;
using System.Collections;

public class IgnoreCollisionScript : MonoBehaviour {
	
	private int colliderLayer1 = 17; 
	private int colliderLayer2 = 18; 
	
	// Use this for initialization
	void Start () 
	{
		Physics.IgnoreLayerCollision(colliderLayer1,colliderLayer2, true);
	}
	
}
