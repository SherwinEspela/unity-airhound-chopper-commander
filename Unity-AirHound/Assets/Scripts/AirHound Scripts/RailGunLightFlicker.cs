using UnityEngine;
using System.Collections;

public class RailGunLightFlicker : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Light>().intensity = Random.Range(-1f,1.5f);
	}
}
