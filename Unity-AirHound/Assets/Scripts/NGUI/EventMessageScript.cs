using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventMessageScript : MonoBehaviour {
	 
	private Animator animatorPanelEventMessage;
	private Text textEventMessage; 

	private int nukesLeft = 5; 
	private string[] randomMessages = {"KEEP GOING!","NICE!","GOOD JOB!","GO GO GO!","EXCELLENT!","IMPRESSIVE!"};

	void Start()
	{
		Invoke ("FindUIElements",0.5f); 
	}

	void FindUIElements()
	{
		animatorPanelEventMessage = GameObject.Find ("PanelEventMessage").GetComponent<Animator>();
		textEventMessage = GameObject.Find ("TextEventMessage").GetComponent<Text>();
	}

	public void InvokeDisplayEventMessage(string message)
	{
		textEventMessage.text = message;
		Invoke("DisplayEventMessage",1.5f); 
	}

	public void InvokeDisplayEventMessageWithNukeNumber()
	{
		int randomNumber = Random.Range(0,randomMessages.Length); 
		
		if (nukesLeft == 1) {
			textEventMessage.text = nukesLeft + " NUKE REMAINING. " + randomMessages[randomNumber];
		} else {
			textEventMessage.text = nukesLeft + " NUKES REMAINING. " + randomMessages[randomNumber];
		}
		
		Invoke("DisplayEventMessage",1.5f);
	}

	void DisplayEventMessage()
	{
		if (nukesLeft != 0) {
			animatorPanelEventMessage.SetTrigger("TriggerShow"); 	
		}
	}

	public void SetNukesLeft(int nukes)
	{
		nukesLeft = nukes; 
	}

	public void DisablePanelEventMessage()
	{
		animatorPanelEventMessage.gameObject.SetActive (false); 
	}
}
