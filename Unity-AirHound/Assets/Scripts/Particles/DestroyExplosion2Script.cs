using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class DestroyExplosion2Script : MonoBehaviour {

	public float fxLength = 5f; 

	// Use this for initialization
	void Start () {
		Destroy(gameObject,fxLength);
		//PoolManager.Pools["Explosions"].Despawn(this.transform);
	}
}
