using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {


	public float turnSpeed = 10.0f;
	public float maxTurnLean = 50.0f;
	public float maxTilt = 50.0f;
	
	public float sensitivity = 10.0f;
	
	public float forwardForce = 1.0f;
	public Transform guiSpeedElement;
	
	private float normalizedSpeed  = 0.2f;
	private Vector3 euler = Vector3.zero;

	public bool horizontalOrientation  = true;


	void Awake () {
		if (horizontalOrientation)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else
		{
			Screen.orientation = ScreenOrientation.Portrait;
		}
		
		guiSpeedElement.position = new Vector3 (0f, normalizedSpeed, 0f);
	}



	// Use this for initialization
	void Start () {
	
	}
	



void  Update () {
	
		foreach ( Touch evt in Input.touches){
	
		if (evt.phase == TouchPhase.Moved)
		{
			normalizedSpeed = evt.position.y / Screen.height;
			guiSpeedElement.position = new Vector3 (0f, normalizedSpeed, 0f);
		}
	}
}

void FixedUpdate () {
	GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, normalizedSpeed * forwardForce);
	
	Vector3 accelerator = Input.acceleration;
	
	// Rotate turn based on acceleration		
	euler.y += accelerator.x * turnSpeed;
	// Since we set absolute lean position, do some extra smoothing on it
	euler.z = Mathf.Lerp(euler.z, -accelerator.x * maxTurnLean, 0.2f);
	
	// Since we set absolute lean position, do some extra smoothing on it
	euler.x = Mathf.Lerp(euler.x, accelerator.y * maxTilt, 0.2f);
	
	// Apply rotation and apply some smoothing
	Quaternion rot = Quaternion.Euler(euler);
	transform.rotation = Quaternion.Lerp (transform.rotation, rot, sensitivity);
}
}
