using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {


/*
This camera script smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/
	
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
    public float height = 5.0f;
	// How much we damp the movement
	public float heightDamping  = 2.0f;
	public float rotationDamping = 3.0f;

	// Use this for initialization
	void Start () {
	
	}


	void LateUpdate (){
		// Early out if we don't have a target
		if (!target)
			return;
		
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight  = target.position.y + height;
		
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		float dt  = Time.deltaTime;
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * dt);//Time.GetMyDeltaTime());
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * dt);//Time.GetMyDeltaTime());
		//System.Console.WriteLine("dt: {0}", dt);//Time.GetMyDeltaTime());
		//Debug.Log("dt: " + Time.deltaTime);
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0f, currentRotationAngle, 0f);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		//transform.position = target.position;
		Vector3 pos = target.position - currentRotation * Vector3.forward * distance;
		pos.y = currentHeight;
		
		// Set the height of the camera
		transform.position = pos;
		
		// Always look at the target
		transform.LookAt (target);
	}

}



