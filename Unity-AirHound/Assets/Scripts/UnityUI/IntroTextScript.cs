using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTextScript : MonoBehaviour {

    public Text textMission1;
    public Text textMission2;
    
	// Use this for initialization
	void Start () {
        string sceneName = SceneManager.GetActiveScene().name;
        string sceneNameTitle = "MISSION " + sceneName.Remove(0, "mission".Length);
        textMission1.text = sceneNameTitle;
        textMission2.text = sceneNameTitle;
        Invoke("HidePanelIntro", 8f);
	}

    void HidePanelIntro()
    {
        this.gameObject.SetActive(false);
    }
}