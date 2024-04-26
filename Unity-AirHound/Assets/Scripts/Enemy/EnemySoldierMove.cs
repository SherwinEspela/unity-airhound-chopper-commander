using UnityEngine;
using System.Collections;

public class EnemySoldierMove : MonoBehaviour {
	
	private Vector3 newPosition;
	public float smooth;
	public Transform chopperTransform;
	public float rangeFar = 5;
	
	// Use this for initialization
//	void Awake () {
//		newPosition = transform.position;
//	}
	
	void Start() 
	{

	}
	
	// Update is called once per frame
	void Update () {
		
		PositionChange(); 
//		if ((Vector3.Distance(transform.position, chopperTransform.position) <= range) && 
//			((transform.position.x - chopperTransform.position.x) > rangeMin) || 
//			((chopperTransform.position.x - transform.position.x) > rangeMin)) {	
//			PositionChange(); 
//		}
		
//		if ((Vector3.Distance(transform.position, chopperTransform.position) > rangeFar)) {	
//			PositionChange();
//			//Debug.Log("target reached"); 
//		}
	}
	
	void PositionChange()
    {
		Vector3 chopperPosition = new Vector3(chopperTransform.position.x,0,0); 
        transform.position = Vector3.Lerp(transform.position, chopperPosition, smooth * Time.deltaTime);
    }

}
