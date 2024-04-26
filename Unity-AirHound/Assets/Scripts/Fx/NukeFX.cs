using UnityEngine;
using System.Collections;

public class NukeFX : MonoBehaviour {

	public GameObject[] nukeFXObjects; 

	// Use this for initialization
	void Start () {
	
	}
	
	public void ShowNukeEffects()
	{
		GameObject nukeFXObject = nukeFXObjects[Random.Range(0,nukeFXObjects.Length)]; 
		GameObject nukeFXClone = Instantiate (nukeFXObject, this.transform.position, this.transform.rotation) as GameObject;

		nukeFXClone.transform.parent = this.transform; 
	}
}
