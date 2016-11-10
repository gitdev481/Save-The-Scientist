using UnityEngine;
using System.Collections;

public class LaunchMissile : MonoBehaviour {
	public GameObject aMissile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// use the Instantiate method to launch a missile
	public void fireMissile(){
		
		Instantiate(aMissile, transform.position, transform.rotation);
		
		
	}
}
