using UnityEngine;
using System.Collections;

[AddComponentMenu("Physics/Constrain Motion")] 

public class ConstrainMotion : MonoBehaviour {

	public bool  xMotion  = true;
	public bool  yMotion  = true;
	public bool  zMotion  = true;


	void FixedUpdate () {

		Vector3 relativeSpeed  = transform.InverseTransformDirection (GetComponent<Rigidbody>().velocity);
		
		if (!xMotion)
			relativeSpeed.x = 0f;
		if (!yMotion)
			relativeSpeed.y = 0f;
		if (!zMotion)
			relativeSpeed.z = 0f;
		
		GetComponent<Rigidbody>().AddRelativeForce (-relativeSpeed, ForceMode.VelocityChange);
	}


}



