using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {
	
	private GameObject chopperMain;
	private Transform chopperTransform;
	public float positionOffset;
	
	// Use this for initialization
	void Start () {
		chopperMain = GameObject.Find("chopperMain");
		chopperTransform = chopperMain.transform; 
	}
	
	// Update is called once per frame
	void Update () {
		if (chopperTransform != null) {
			transform.position = new Vector3(chopperTransform.position.x + positionOffset,transform.position.y,transform.position.z);
		}
	}
}
