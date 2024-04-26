using UnityEngine;
using System.Collections;

public class ExploderInsurance : MonoBehaviour {

	private GameObject exploder;

	// Use this for initialization
	void Start () {
		exploder = GameObject.Find("Exploder");
	}
	
	// Update is called once per frame
	void Update () {
		if (exploder) {
			exploder.transform.position = transform.position;	
		}
	}
}
