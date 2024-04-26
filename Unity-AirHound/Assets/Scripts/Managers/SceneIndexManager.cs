using UnityEngine;
using System.Collections;

public class SceneIndexManager : MonoBehaviour {
		
	public static int sceneIndex;
	//public GameObject labelMissionName; 
	//private UILabel labelMissionNameUILabelScript; 
	//public AnimationClip labelMissionNameClip; 
	//public GameObject lockedIcon;
	//private UISprite lockedIconUISpriteScript;
	//public AnimationClip lockedIconClip; 

	void Start()
	{
		sceneIndex = 1;
		//lockedIconUISpriteScript = lockedIcon.GetComponent<UISprite>();
		//labelMissionNameUILabelScript = labelMissionName.GetComponent<UILabel>(); 
	}

	public void IncrementMissionNumber()
	{
		if (sceneIndex != 8) {
			sceneIndex++; 
		}

		//PlayMissionLabelAnimation();
		//PlayLockedIconAnimation();
	}

	public void DecrementMissionNumber()
	{
		if (sceneIndex != 1) {
			sceneIndex--;
		}

		//PlayMissionLabelAnimation();
		//PlayLockedIconAnimation();
	}

//	void PlayMissionLabelAnimation()
//	{
//		labelMissionNameUILabelScript.alpha = 0; 
//		TweenAlpha.Begin(labelMissionName,0.5f,1f);
//
//		labelMissionName.animation.Play(labelMissionNameClip.name);
//	}
//
//	void PlayLockedIconAnimation()
//	{
//		lockedIconUISpriteScript.alpha = 0f; 
//		TweenAlpha.Begin(lockedIcon,0.5f,0.7f);
//		lockedIcon.animation.Play(lockedIconClip.name);
//	}
}
