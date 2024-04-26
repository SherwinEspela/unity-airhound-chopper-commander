using UnityEngine;
using System.Collections;

public class NukeZone : MonoBehaviour {

	public int nukeZone;

	void SetNukeZone()
	{
		if (nukeZone == 1) {
			SurvivalMissionScript.pickedNukeAtZone1 = true;	
		}

		else if (nukeZone == 2) {
			SurvivalMissionScript.pickedNukeAtZone2 = true;
		} 

		else {
			SurvivalMissionScript.pickedNukeAtZone3 = true;
		}
	}
}
