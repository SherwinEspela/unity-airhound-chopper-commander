using UnityEngine;
using System.Collections;

public class PickUpNukeCrate : MonoBehaviour {
	
//	private Vector3 newPosition;
//	private Vector3 upPosition; 
//	private Vector3 downPosition;
//	private bool foundNuke = false;
//	public float smooth = 2f; 
//	
//	void Start()
//	{
//		newPosition = transform.position;
//		upPosition = transform.position; 
//	}
//	
//	void Update()
//	{
//		LowerClaw(); 
//	}
//	
//	public void LowerClaw()
//	{
//		downPosition = new Vector3(upPosition.x,-2f,upPosition.z);
//		
//		if (foundNuke) {
//			newPosition = downPosition; 
//		} else {
//			newPosition = upPosition; 
//		}
//		
//		transform.position = Vector3.Lerp(transform.position,newPosition,Time.deltaTime*smooth);
//	}
//	
//	public void hasFoundNuke() 
//	{
//		foundNuke = true; 
//	}
//	
//	public void hasLeftNuke()
//	{
//		foundNuke = false; 
//	}
	
	public AnimationClip nukePickerDown; 
	public AnimationClip nukePickerUp;
	
	public void PickerDown()
	{
		GetComponent<Animation>().Play(nukePickerDown.name);
	}
	
	public void PickerUp()
	{
		GetComponent<Animation>().Play(nukePickerUp.name);
	}
}
