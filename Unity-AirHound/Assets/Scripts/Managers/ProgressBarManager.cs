using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic; 

public class ProgressBarManager : MonoBehaviour {

	private float progressBarValue; //1110f  
	private float groundValue;  
	private RectTransform imageChopper;
	private Image chopperIconImageScript; 
	private float imageChopperPositionX = 0;
	private float imageChopperPositionY; 
	private Transform chopper; 
	private List<GameObject> imageProgressBarNukeLists = new List<GameObject>(); 
	private bool uiElementsFound = false;
	private RectTransform pihRectTransform; 
	private const float offsetValue = 8f; 
	private const float offsetValue2 = 16f;
	private GameObject panelIndicatorHolder;
	private float farthestProgressBarNukeValue = 0f;

	public GameObject imageProgressBarNuke; 
	public GameObject[] nukeCrates; 
	public Sprite spriteChopperIconNormal; 
	public Sprite spriteChopperIconReversed; 

	// Use this for initialization
	void Start () {
		Invoke ("FindUIElements",1f); 
	}

	void FindUIElements()
	{
		GameObject chopperGo = GameObject.Find ("chopperMain"); 
		chopper = chopperGo.transform; 
		GameObject deliveryTruck = GameObject.Find ("DeliveryTruck");

		float farthestNuke = 0; 
		foreach (var nuke in nukeCrates) {
			float nukePositionX = nuke.transform.position.x; 
			if (nukePositionX > farthestNuke) {
				farthestNuke = nukePositionX; 
			} 
		}
		
		groundValue = farthestNuke - deliveryTruck.transform.position.x;  
		
		// find the ImageChopper
		GameObject imageChopperGo = GameObject.Find ("ImageChopper"); 
		imageChopper = imageChopperGo.GetComponent<RectTransform>(); 
		imageChopperPositionY = imageChopper.anchoredPosition.y;
		chopperIconImageScript = imageChopperGo.GetComponent<Image>();  
		
		panelIndicatorHolder = GameObject.Find ("PanelIndicatorHolder"); 
		pihRectTransform = panelIndicatorHolder.GetComponent<RectTransform>(); 
		progressBarValue = pihRectTransform.rect.width; 
		
		// add the nukeIndicators to the panelIndicatorHolder
		int nameCounter = 1; 
		foreach (var nuke in nukeCrates) {
			GameObject ipbnClone = Instantiate(imageProgressBarNuke) as GameObject;
			ipbnClone.transform.SetParent(panelIndicatorHolder.transform); 
			RectTransform rtScript = ipbnClone.GetComponent<RectTransform>(); 
			float nukeIndicatorPositionX = progressBarValue * (nuke.transform.position.x + offsetValue) / groundValue; 
			rtScript.anchoredPosition = new Vector2(nukeIndicatorPositionX + offsetValue2,imageChopperPositionY);
			nuke.name = nameCounter + "_" + nuke.name; 
			ipbnClone.name = nameCounter + "_" + ipbnClone.name;
			imageProgressBarNukeLists.Add(ipbnClone); 
			nameCounter++; 
		}

		uiElementsFound = true; 
	}
	
	// Update is called once per frame
	void Update () {
		if (uiElementsFound) {
			UpdateProgressBarElements(); 	
		}
	}

	void UpdateProgressBarElements()
	{
		imageChopperPositionX = progressBarValue * (chopper.position.x + offsetValue) / groundValue;  
		
		if (imageChopperPositionX > progressBarValue) {
			imageChopperPositionX = progressBarValue; 	
		}
		if (imageChopperPositionX < 0f) {
			imageChopperPositionX = 0f; 	
		}
		
		imageChopper.anchoredPosition = new Vector2 (imageChopperPositionX,imageChopperPositionY); 
	}

	public void ChangeChopperIconToNormal()
	{
		chopperIconImageScript.sprite = spriteChopperIconNormal; 
	}

	public void ChangeChopperIconToReversed()
	{
		chopperIconImageScript.sprite = spriteChopperIconReversed;
	}

	public void HideNukeIndicator(string nukeCrateMainName)
	{
		string numberString = nukeCrateMainName.Substring (0,1); 
	
		foreach (var imageNuke in imageProgressBarNukeLists) {
			if (numberString.Equals(imageNuke.name.Substring(0,1))) {
				imageNuke.SetActive(false);
				break; 
			}	
		}
	}
}