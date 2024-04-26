using UnityEngine;
using System.Collections;
using PathologicalGames;

public class LaunchRocketScript : MonoBehaviour {
	
	public GameObject rocket;
	public float speed = 10f; 
	public AudioClip[] rocketSounds;

	void Start()
	{

	}

	void LaunchRocket() 
	{
		Transform clone = PoolManager.Pools["Projectiles"].Spawn(rocket.transform,transform.position,transform.rotation);
		clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,speed));
		if (GetComponent<AudioSource>()) {
			GetComponent<AudioSource>().PlayOneShot(rocketSounds[Random.Range(0,rocketSounds.Length)]); 
		}
	}
}
