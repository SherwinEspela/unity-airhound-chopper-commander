﻿using UnityEngine;
using System.Collections;

public class moveCameraScript : MonoBehaviour {
	
//	public float smooth = 1;
//    private Vector3 newPosition;
	
	public AnimationClip moveCameraLeftClip;
	public AnimationClip moveCameraRightClip;
	
//	void Awake ()
//    {
//        newPosition = transform.position;
//	}
	
	public void MoveCameraLeft()
	{
		GetComponent<Animation>().Play(moveCameraRightClip.name);
	}
	
	public void MoveCameraRight()
	{
		GetComponent<Animation>().Play(moveCameraLeftClip.name);
	}
	
//	public void MoveCamera()
//	{
//		Debug.Log("MoveCamera function..."); 
////		Vector3 positionA = new Vector3(-4.51f, 0, 0);
////		Vector3 positionB = new Vector3(0, 0, 0);
//// 
//		if (transform.position.x >= 0) {
////			newPosition = positionA;
////			transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
//			animation.Play(moveCameraLeftClip.name);
//		} 
//		else if (transform.position.x <= -5.0f) {
////			newPosition = positionB;
////			transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
//			animation.Play(moveCameraRightClip.name);
//		}
//	}
}
