using UnityEngine;
using System.Collections;
using Exploder;

public class ExplosionManager : MonoBehaviour {

	public ExploderObject exploder; 
	public static bool destroyedByRocket = false; 

	public void ExplodeObject(GameObject objectToExplode)
	{
		ExploderUtils.SetActive(exploder.gameObject, true);
		if (destroyedByRocket) {
			exploder.Force = Random.Range(7,11); 
		} else {
			exploder.Force = Random.Range(3,6);
		}

		exploder.transform.position = objectToExplode.transform.position;
		exploder.ExplodeObject (objectToExplode);
	}
}
