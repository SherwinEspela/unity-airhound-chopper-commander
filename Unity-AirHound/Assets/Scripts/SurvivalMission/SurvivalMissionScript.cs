using UnityEngine;
using System.Collections;

public class SurvivalMissionScript : MonoBehaviour {

	public static bool pickedNukeAtZone1 = false;
	public static bool pickedNukeAtZone2 = false;
	public static bool pickedNukeAtZone3 = false;
//	public Transform nukeSpawnerZone1;
//	public Transform nukeSpawnerZone2;
//	public Transform nukeSpawnerZone3;
	public GameObject nukeGreenPrefab; 
	public GameObject nukeBluePrefab;
	public GameObject nukeOrangePrefab;

	public static bool isSurvivalMission = false;

	public static Transform nukeCrateGroup; 
	private Vector3 nukeCratePosition = new Vector3(-0.03400421f,0.5559801f,0.8207415f);
	private Vector3 nukeFXHolderPosition = new Vector3(-0.03719711f,1.114785f,0.8265402f);
	public static Quaternion nukeCrateRotation; 

	void Start()
	{
		isSurvivalMission = true;

		pickedNukeAtZone1 = false; 
		pickedNukeAtZone2 = false;
		pickedNukeAtZone3 = false;
	}

	public void ReparentNukeCrate(Transform nukeCrate)
	{
		nukeCrate.parent = nukeCrateGroup;
		nukeCrate.localPosition = nukeCratePosition;
		nukeCrate.localRotation = nukeCrateRotation; 
		nukeCrate.GetComponent<Collider>().enabled = true; 
	}

	public void ReparentNukeFXHolder(Transform nukeFXHolder)
	{
		nukeFXHolder.parent = nukeCrateGroup;
		nukeFXHolder.localPosition = nukeFXHolderPosition;
	}

	public void SetSurvivalMissionOff()
	{
		isSurvivalMission = false; 
	}
}
