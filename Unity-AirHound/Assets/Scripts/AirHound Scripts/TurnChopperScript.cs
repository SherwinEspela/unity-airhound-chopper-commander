using UnityEngine;
using System.Collections;

public class TurnChopperScript : MonoBehaviour {
	
	private bool chopperIsTurned = false;
	private const float turnRate = 1.2f;
	private float nextTurn;
	private GameObject buttonDirection2;  
	private EasyButton buttonDirection2Script; 
	// button direction textures
	private Texture2D buttonDirectionNormalLeft; 
	private Texture2D buttonDirectionNormalRight;
	private Texture2D buttonDirectionPressedLeft; 
	private Texture2D buttonDirectionPressedRight;

	public AnimationClip turnForwardClip;
	public AnimationClip turnBackwardClip;
	public Transform cameraTransform;
	public GameObject gameManager;
	public GameObject helixRotate; 
	public GameObject buttonFire1;
	public GameObject buttonRockets; 

	// static members
	public static bool isChopperFacingBack = false;

	// event
	public delegate void ChopperTurnedBackAction();
	public static event ChopperTurnedBackAction OnChopperTurnedBack;
	public delegate void ChopperTurnedFrontAction();
	public static event ChopperTurnedFrontAction OnChopperTurnedFront;

	void Start()
	{
		isChopperFacingBack = false;

		buttonDirection2 = GameObject.Find("buttonDirection2");
		buttonDirection2Script = buttonDirection2.GetComponent<EasyButton>(); 

		// load the button direction textures
		buttonDirectionNormalLeft = Resources.Load("Button_04_Normal_Left") as Texture2D; 
		buttonDirectionNormalRight = Resources.Load("Button_04_Normal_Right") as Texture2D;
		buttonDirectionPressedLeft = Resources.Load("Button_01_Normal_Left") as Texture2D; 
		buttonDirectionPressedRight = Resources.Load("Button_01_Normal_Right") as Texture2D;
	}
	
	void onEnable() 
	{
		EasyButton.On_ButtonDown += On_ButtonDown;
	}
	
	void On_ButtonDown (string buttonName)
	{
		Turn(); 
	}

	void Update()
	{
		if (GetComponent<Animation>().isPlaying) {
			buttonFire1.SetActive(false);
		} else {
			buttonFire1.SetActive(true);
		}
	}

	public void Turn()
	{
		if (Time.time > nextTurn) {
			nextTurn = Time.time + turnRate;

			if (chopperIsTurned) {
				buttonDirection2Script.NormalTexture = buttonDirectionNormalLeft; 
				buttonDirection2Script.ActiveTexture = buttonDirectionPressedLeft;
				GetComponent<Animation>().Play(turnForwardClip.name);
				cameraTransform.SendMessage("MoveCameraLeft",SendMessageOptions.DontRequireReceiver);
				chopperIsTurned = false;
				gameManager.SendMessage("ChopperFacesFront",SendMessageOptions.DontRequireReceiver);
				helixRotate.SendMessage("TurnHelixRight",SendMessageOptions.DontRequireReceiver);
				gameManager.SendMessage("ChangeChopperIconToNormal",SendMessageOptions.DontRequireReceiver);
			
				isChopperFacingBack = false;
				if (OnChopperTurnedFront != null) {
					OnChopperTurnedFront ();
				}
			} else {
				buttonDirection2Script.NormalTexture = buttonDirectionNormalRight; 
				buttonDirection2Script.ActiveTexture = buttonDirectionPressedRight; 
				GetComponent<Animation>().Play(turnBackwardClip.name);
				cameraTransform.SendMessage("MoveCameraRight",SendMessageOptions.DontRequireReceiver); 
				chopperIsTurned = true; 
				gameManager.SendMessage("ChopperFacesBack",SendMessageOptions.DontRequireReceiver);
				helixRotate.SendMessage("TurnHelixLeft",SendMessageOptions.DontRequireReceiver);
				gameManager.SendMessage("ChangeChopperIconToReversed",SendMessageOptions.DontRequireReceiver); 

				isChopperFacingBack = true;
				if (OnChopperTurnedBack != null) {
					OnChopperTurnedBack ();
				}
			}
		}
	}
}
