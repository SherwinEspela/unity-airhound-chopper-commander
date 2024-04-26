using UnityEngine;
using System.Collections;

public class TankRotateOffsetScript : MonoBehaviour {
	
	//public int rotateYOffset = -25;
	public Transform tankRotateOffset; 

	public void SetRotateYOffset(int offsetValueY)
	{
		this.tankRotateOffset.Rotate(new Vector3(0,offsetValueY,0));
	}
	
	void OnDespawned()
	{
		tankRotateOffset.localRotation = new Quaternion(0,0,0,0); 
	}
}
