using UnityEngine;
using System.Collections;

public class EnemyDetectorScript : MonoBehaviour {
	
	private Vector3 newPosition;
	public float smooth = 0.5f;
	public Transform chopperTransform;
	private bool isRepositioning = false; 
	private float range; 
	public Transform soldierObject; 
	
	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			Debug.Log("Chopper detected");
			range = Random.Range(5,10); 
			Debug.Log("range =" + range);
			isRepositioning = true; 
		} 
	}
	
	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			Debug.Log("Chopper Left");
			//isFollowing = true; 
		} 
	}
	
	void Update()
	{	
		
		if ((Vector3.Distance(transform.position, chopperTransform.position) > range)){
			isRepositioning = false; 
		}
		
		if (isRepositioning) {
			SoldierRun(); 
			Reposition(); 	
		} else {
			SoldierFire(); 
		}
	}
	
	void PositionChange()
    {
		Vector3 chopperPosition = new Vector3(chopperTransform.position.x,0,0); 
        transform.position = Vector3.Lerp(transform.position, chopperPosition, smooth * Time.deltaTime);
    }
		
	void Reposition()
    {
		newPosition = new Vector3((transform.position.x + 5),0,0); 
        transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
    }
	
	void SoldierFire()
	{
		soldierObject.SendMessage("Fire",SendMessageOptions.DontRequireReceiver);
	}
	
	void SoldierRun()
	{
		soldierObject.SendMessage("Run",SendMessageOptions.DontRequireReceiver);
	}
}
