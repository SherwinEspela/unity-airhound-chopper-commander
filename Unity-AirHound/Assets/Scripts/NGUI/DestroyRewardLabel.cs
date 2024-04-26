using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class DestroyRewardLabel : MonoBehaviour {
	
	void Start () {
		PoolManager.Pools["Miscs"].Despawn(this.gameObject.transform,1.8f);
	}
}
