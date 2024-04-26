using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class ExploderPlacement : MonoBehaviour {

	private GameObject exploder;
	public GameObject[] explosionObjects; 
	public bool isAirDrone = false; 

	void Start()
	{
		exploder = GameObject.Find("Exploder");
	}

	void Update()
	{
		if (exploder) {
			exploder.SetActive(true);	
		}
	}

	public void PlaceExploder()
	{
		if (isAirDrone) {
			int randomNumber = Random.Range(0,10);
			if (randomNumber >= 5) {
				DoExploderProcess(); 
			}
		} else {
			DoExploderProcess();
		}
	}

	void DoExploderProcess()
	{
		GameObject objectToExplode = null;
		foreach (GameObject explosionObject in explosionObjects) {
			Transform clone = PoolManager.Pools["Explosions"].Spawn(
				explosionObject.transform,
				transform.position,
				transform.rotation
			);
			objectToExplode = clone.gameObject;
			RepositionTheExploder (objectToExplode);
		}
	}

	void RepositionTheExploder(GameObject objectToExplode)
	{
		if (exploder == null) {
			exploder = GameObject.Find("Exploder");
		}

		if (exploder) {
			GameManagerScript.gameManagerStatic.SendMessage(
				"ExplodeObject",
				objectToExplode,
				SendMessageOptions.DontRequireReceiver
			);
		}
	}
}