using UnityEngine;
using System.Collections;

public class MissionOutcomeScript : MonoBehaviour {
	
	// Mission Complete
	public GameObject panelMissionComplete;
	public GameObject missionCompleteMessageBG;
	public GameObject missionCompleteMessageLabel;

	public GameObject congratulationsMessageLabel;
	public GameObject panelMissionCompleteMessage;

	// Mission Failed
	public GameObject missionFailedMessageGroup;
	public GameObject missionFailedMessageBG;
	public GameObject missionFailedMessageLabel; 
	public GameObject destroyedMessageLabel;

	// Buttons	
	public GameObject missionOutcomeButtonGroup;
	public GameObject playAgainButton;
	public GameObject nextMissionButton; 
	public GameObject mainMenuButton;
	public GameObject playAgainLabel;
	public GameObject nextMissionLabel; 
	public GameObject mainMenuLabel;

	// Animation Clips
	public AnimationClip missionOutcomeClip; 
	public AnimationClip missionOutcomeButtonClip; 

	// Scores Labels
	public GameObject scoreGroup; 
	public GameObject timeFinishedLabel;

	public GameObject enemiesDestroyedLabel; 
	public GameObject bonusScoreLabel; 
	public GameObject missionScoreLabel; 
	public GameObject totalScoreLabel; 
	public GameObject timeFinishedValueLabel;

	public GameObject enemiesDestroyedValueLabel; 
	public GameObject bonusScoreValueLabel; 
	public GameObject missionScoreValueLabel; 
	public GameObject totalScoreValueLabel;
	public GameObject scoreBackgroundSprite; 

	// stars
//	public GameObject starsGroup;
//	public GameObject starsLeftGroup;
//	public GameObject starsRightGroup;
//	public AnimationClip starsLeftGroupClip;
//	public AnimationClip starsRightGroupClip;

	public GameObject nextMissionButtonGroup; 
	public GameObject mainMenuButtonGroup;

	void Start()
	{

	}

	public void MissionCompleteEnter()
	{
		panelMissionComplete.SetActive(true);
		//starsGroup.SetActive(true); 

		// if it is mission 8, which is the last mission
		if (SceneIndexManager.sceneIndex == 8 || GameDifficulty.gameDifficulty == GameDifficulty.Difficulty.easy) {
			nextMissionButtonGroup.SetActive(false);
			mainMenuButtonGroup.transform.localPosition = new Vector3(0f,-190f,0f);
		} else {
			nextMissionButtonGroup.SetActive(true);
		}



		panelMissionComplete.GetComponent<Animation>().Play(missionOutcomeClip.name);


		CommonElementsEnter();

		// Stars
//		starsLeftGroup.animation.Play(starsLeftGroupClip.name); 
//		starsRightGroup.animation.Play(starsRightGroupClip.name); 
	}

	public void MissionFailedEnter()
	{
		missionFailedMessageGroup.SetActive(true);
		nextMissionButtonGroup.SetActive(false);

		//mainMenuLabelButtonScript.functionName = "OpenConfirmMessageByMissionFailedMenu";
		mainMenuButtonGroup.transform.localPosition = new Vector3(0f,-190f,0f);

		missionFailedMessageGroup.GetComponent<Animation>().Play(missionOutcomeClip.name);

		CommonElementsEnter();
	}

	void CommonElementsEnter()
	{
		missionOutcomeButtonGroup.SetActive(true); 
		scoreGroup.SetActive(true); 
		
		missionOutcomeButtonGroup.GetComponent<Animation>().Play(missionOutcomeButtonClip.name); 

	}

	public void HideMissionCompleteOutcome()
	{
		panelMissionComplete.SetActive(false);
		missionOutcomeButtonGroup.SetActive(false); 
		scoreGroup.SetActive(false); 
	}

	public void ShowMissionCompleteOutcome()
	{
		panelMissionComplete.SetActive(true);
		missionOutcomeButtonGroup.SetActive(true); 
		scoreGroup.SetActive(true); 
		//starsGroup.SetActive(true); 
	}

	public void HideMissionFailedOutcome()
	{
		missionFailedMessageGroup.SetActive(false);
		missionOutcomeButtonGroup.SetActive(false); 
		scoreGroup.SetActive(false);  
	}
	
	public void ShowMissionFailedOutcome()
	{
		missionFailedMessageGroup.SetActive(true);
		missionOutcomeButtonGroup.SetActive(true); 
		scoreGroup.SetActive(true); 
	}	
}
