using UnityEngine;
using System.Collections;

public class PoolLoaderManager : MonoBehaviour {

	public GameObject explosionFXPool; 

	// Use this for initialization
	void Start () {
		LoadSpawnPoolsPrefab (); 
	}

	void LoadSpawnPoolsPrefab()
	{
		Instantiate (explosionFXPool); 
	}
}
