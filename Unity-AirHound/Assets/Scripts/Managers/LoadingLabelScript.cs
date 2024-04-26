using UnityEngine;
using System.Collections;

public class LoadingLabelScript : MonoBehaviour {

	public AnimationClip loadingLabelClip;

	// Use this for initialization
	void Start () {
		GetComponent<Animation>().Play(loadingLabelClip.name);
	}
}
