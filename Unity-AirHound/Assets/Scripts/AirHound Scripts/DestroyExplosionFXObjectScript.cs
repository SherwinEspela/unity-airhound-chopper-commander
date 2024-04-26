using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class DestroyExplosionFXObjectScript : MonoBehaviour {

	public float delayTime = 3f; 

	// Use this for initialization
	void Awake () {
		Destroy(gameObject,delayTime);
		//PoolManager.Pools["Explosions"].Despawn(this.transform); 
	}	
}
