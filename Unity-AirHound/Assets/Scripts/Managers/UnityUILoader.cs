using UnityEngine;
using UnityEngine.UI; 
//using TMPro;
using System.Collections;

public class UnityUILoader : MonoBehaviour {

	public GameObject canvasScreenSpacePrefab; 
	public GameObject canvasPauseAndNavUIPrefab; 
	public GameObject eventSystem;
    //private TextMeshProUGUI textMeshProMission;
    private Text textMission; 
	private Canvas canvasScreenSpacePrefabScript; 
	private Canvas canvasPauseAndNavUIPrefabScript;

	// Use this for initialization
	void Start () {
		Instantiate (eventSystem);

		GameObject canvasClone = Instantiate (canvasScreenSpacePrefab) as GameObject; 
		GameObject canvasPauseAndNavClone = Instantiate (canvasPauseAndNavUIPrefab) as GameObject;

		canvasScreenSpacePrefabScript = canvasClone.GetComponent<Canvas>(); 
		canvasPauseAndNavUIPrefabScript = canvasPauseAndNavClone.GetComponent<Canvas>();

        //textMeshProMission = GameObject.Find("TextMeshProMission").GetComponent<TextMeshProUGUI>(); 
        //textMeshProMission.text = "MISSION " + SceneIndexManager.sceneIndex; 

        //this.textMission = GameObject.Find("TextMission").GetComponent<Text>();
        //this.textMission.text = "MISSION " + SceneIndexManager.sceneIndex;

        StartCoroutine (SwitchCanvasOrder());
		StartCoroutine (DisableTextMeshProMission()); 
	}

	IEnumerator SwitchCanvasOrder()
	{
		yield return new WaitForSeconds(4f);

		canvasScreenSpacePrefabScript.sortingOrder = 0;
		canvasPauseAndNavUIPrefabScript.sortingOrder = 10; 
	}

	IEnumerator DisableTextMeshProMission()
	{
		yield return new WaitForSeconds(12f);

        //textMeshProMission.gameObject.SetActive (false); 
        //textMission.gameObject.SetActive(false);
	}
}
