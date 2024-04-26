using UnityEngine;
using System.Collections;

public class FlareShimmer : MonoBehaviour {

	public ProFlare proFlareScript; 
	public int scaleMin; 
	public int scaleMax;  
	public float smooth = 10f;
	public float changeRate = 2f; 
	private float nextChange; 
	private int newScaleValue; 

	// Update is called once per frame
	void Update () {
		ScaleChanging();  
	}

	private void ScaleChanging()
	{
		if (Time.time > nextChange) {	
			int randomScaleValue = Random.Range(scaleMin,scaleMax); 
			newScaleValue = randomScaleValue;
			nextChange = Time.time + changeRate;
		}

		proFlareScript.GlobalScale = Mathf.Lerp(proFlareScript.GlobalScale,newScaleValue,smooth * Time.deltaTime); 
	}
}
