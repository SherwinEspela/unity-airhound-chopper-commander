using UnityEngine;
using System.Collections;

public class ControlsGUI : MonoBehaviour {
	
	public GUISkin mainSkin;
	public Transform chopperPosition; 
	public Transform chopperRotation; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		
		GUI.skin = mainSkin; 
		
		// Top Label
		int labelWidth = 200; 
		int labelXPos = (Screen.width/2) - (labelWidth/2);
		GUI.Label (new Rect(labelXPos,20,labelWidth,40),"Game Project: Controls Test");
		
		// DPad
		int buttonVerticalPad = 10;
		int buttonHorizontalPad = 20; 
		int buttonWidth = 80;
		int buttonHeight = 50; 
		int upButtonXPos = 80; 
		int upButtonYPos = 450;
		int leftButtonXPos = 30; 
		int leftButtonYPos = upButtonYPos + buttonHeight + buttonVerticalPad;
		int rightButtonXPos = leftButtonXPos + buttonWidth + buttonHorizontalPad;
		int rightButtonYPos = leftButtonYPos;
		int downButtonXPos = upButtonXPos;
		int downButtonYPos = leftButtonYPos + buttonVerticalPad + buttonHeight;
		
		if (GUI.Button (new Rect (upButtonXPos,upButtonYPos,buttonWidth,buttonHeight),"Up")) {
			print("Tapped Up Button");
			MoveChopperUp(); 
		}
		
		if (GUI.Button (new Rect (leftButtonXPos,leftButtonYPos,buttonWidth,buttonHeight),"Left")) {
			print("Tapped Left Button");
			RotateChopperLeft(); 
		}
		
		if (GUI.Button (new Rect (rightButtonXPos,rightButtonYPos,buttonWidth,buttonHeight),"Right")) {
			print("Tapped Right Button");
			RotateChopperRight(); 
		}
		
		if (GUI.Button (new Rect (downButtonXPos,downButtonYPos,buttonWidth,buttonHeight),"Down")) {
			print("Tapped Down Button");
			MoveChopperDown(); 
		}
		
		// Fire Buttons
		int fireButtonPad = 20; 
		int fireButtonWidth = 80;
		int fireButtonHeight = 80;
		int fire1ButtonXPos = Screen.width - fireButtonWidth - 30;
		int fire1ButtonYPos = Screen.height - fireButtonHeight - 40;
		int fire2ButtonXPos = fire1ButtonXPos - fireButtonPad - fireButtonWidth;
		int fire2ButtonYPos = fire1ButtonYPos; 
		
		if (GUI.Button (new Rect (fire1ButtonXPos,fire1ButtonYPos,fireButtonWidth,fireButtonHeight),"Fire1")) {
			print("Tapped Fire1 Button");
		}
		
		if (GUI.Button (new Rect (fire2ButtonXPos,fire2ButtonYPos,fireButtonWidth,fireButtonHeight),"Fire2")) {
			print("Tapped Fire2 Button");
		}
	}
	
	void MoveChopperUp()
	{
		chopperPosition.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
	}
	
	void MoveChopperDown()
	{
		chopperPosition.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
	}
	
	void RotateChopperLeft()
	{
		chopperRotation.transform.Rotate(0,Time.deltaTime*20, 0);
	}
	
	void RotateChopperRight()
	{
		chopperRotation.transform.Rotate(0,-Time.deltaTime*20, 0);
	}
}
