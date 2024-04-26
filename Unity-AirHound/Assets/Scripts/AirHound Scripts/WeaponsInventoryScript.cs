using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponsInventoryScript : MonoBehaviour {
	
	// weapon inventory
	private string playerPrefsRocketInventory = "PlayerPrefsRocketInventory"; 
	private int rocket;
	private int maximumRockets = 10; 
	private Text textRocketValue;  	
	public AudioClip noAmmoSound; 
	
	public int Rocket
	{
		get; 
		set; 
	}

	public static bool rocketEmpty = false; 
	private Animator textRocketValueAnimator; 

	// Use this for initialization
	void Start () {
		Rocket = maximumRockets; 
		Invoke ("FindUIElements",2f); 

		rocketEmpty = false; 
	}

	void FindUIElements()
	{
		textRocketValue = GameObject.Find ("TextRocketValue").GetComponent<Text>();
		if (Rocket <= 9) {
			textRocketValue.text = "0" + Rocket.ToString();
		} else {
			textRocketValue.text = Rocket.ToString();
		}

		textRocketValueAnimator = GameObject.Find("TextRocketValue").GetComponent<Animator>(); 
	}

	public void DecreaseRocketInventory()
	{
		Rocket--;
		if (Rocket <= 0) {
			Rocket = 0;
			rocketEmpty = true;
			textRocketValueAnimator.SetBool("rocketIsEmpty",true); 
		}

		UpdateTextRocketValue (); 
	}
	
	public void AddRocketInventory(int bonusRocket)
	{
		Rocket += bonusRocket; 
		if (Rocket > maximumRockets) {
			Rocket = maximumRockets; 
		}
		UpdateTextRocketValue (); 
		rocketEmpty = false;
		textRocketValueAnimator.SetBool("rocketIsEmpty",false);
	}

	public void ReplenishRocketInventory()
	{
		rocketEmpty = false;
		textRocketValueAnimator.SetBool("rocketIsEmpty",false);
		Rocket += maximumRockets; 
		if (Rocket > maximumRockets) {
			Rocket = maximumRockets; 
		}
		UpdateTextRocketValue (); 
	}

	void UpdateTextRocketValue()
	{
		if (Rocket <= 9) {
			textRocketValue.text = "0" + Rocket.ToString();
		} else {
			textRocketValue.text = Rocket.ToString();
		}
	}
	
	public void PlayNoAmmoSound()
	{
		GetComponent<AudioSource>().PlayOneShot(noAmmoSound); 
	}

	public void SetRocketInventory()
	{
		maximumRockets++;
		if (maximumRockets > 20) {
			maximumRockets = 20; 	
		}
		PlayerPrefs.SetInt(playerPrefsRocketInventory,maximumRockets); 
	}

	public int GetRocketInventory()
	{
		return maximumRockets; 
	}
}
