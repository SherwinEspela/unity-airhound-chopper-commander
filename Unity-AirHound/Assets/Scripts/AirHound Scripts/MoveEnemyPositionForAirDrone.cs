using UnityEngine;
using System.Collections;

public class MoveEnemyPositionForAirDrone : MonoBehaviour {

	public int translateX = 0;
	public float smooth = 5f;
	//public int initialYPosition = -3;
	//public bool isAirBuzzer;
//	public float maxYPos = -3;
//	public float minYPos = -5; 

//	public void SetInitialYPosition(int positionYInitial)
//	{
//		if (isAirBuzzer) {
//			float randomYPos = Random.Range(minYPos,maxYPos);
//			transform.Translate(new Vector3(0,randomYPos,0));
//		}
//		
//		else {
//			//transform.Translate(new Vector3(0,initialYPosition,0));
//			this.transform.position = new Vector3(0,0,0); 
//		}
//	}


	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(translateX * Time.deltaTime * smooth,0,0)); 
	}
}
