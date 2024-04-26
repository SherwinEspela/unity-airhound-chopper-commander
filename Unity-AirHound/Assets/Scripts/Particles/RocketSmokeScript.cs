using UnityEngine;
using System.Collections;

public class RocketSmokeScript : MonoBehaviour {

	void StopParticleEmission()
	{
		gameObject.GetComponent<ParticleSystem>().enableEmission = false; 
	}
}
