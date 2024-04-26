using UnityEngine;
using System.Collections;

public class MoveEnemyPositionScript : MonoBehaviour {
	
	public int translateX = 0;
	public float smooth = 5f; 

	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(translateX * Time.deltaTime * smooth,0,0)); 
	}	
}
