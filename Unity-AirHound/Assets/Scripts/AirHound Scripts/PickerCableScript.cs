using UnityEngine;
using System.Collections;

public class PickerCableScript : MonoBehaviour {
	
	public Transform picker;
	private LineRenderer lineRenderer; 
	private int layerItemPicker = 1<<25;
	
	// Use this for initialization
	void Start () {
		lineRenderer = gameObject.GetComponent<LineRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit; 
		if (Physics.Linecast(transform.position, picker.position,out hit,layerItemPicker)) {
			lineRenderer.SetPosition(1,new Vector3(0,-hit.distance,0));
		}
	}
}
