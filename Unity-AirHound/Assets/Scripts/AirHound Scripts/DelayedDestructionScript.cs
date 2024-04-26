using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class DelayedDestructionScript : MonoBehaviour {

	public float seconds; 
	
	public void InvokeDestroyObject()
	{
		Invoke("DestroyObject",seconds);
	}
	
	void DestroyObject()
	{
		//Destroy(gameObject);
		PoolManager.Pools["Environments"].Despawn(gameObject.transform);
	}
}
