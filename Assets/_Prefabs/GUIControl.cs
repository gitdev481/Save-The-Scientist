using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	// create GameObject variable
	GameObject cannon;
	
	int numberOfMissiles = 0;
	string missileCount;


	// call the OnGUI method
	public void OnGUI () {
		
		
		GUI.TextField (new Rect (400,  30,   50,      20), missileCount,      25);     
		                     // xPos, yPos, xWidth, yHeight)             stringLength
		
		if (GUI.Button (new Rect (10,   10,   50,      40),    "Fire!")) {
			                  // xPos, yPos, xWidth, yHeight) buttonText

			// gets the script attached to the 'Launcher' GameObject called 'LaunchMissile'
			// calls the method in the script named 'firemissile()'
			cannon.GetComponent<LaunchMissile>().fireMissile();

			// call the setNumberOfTries() method to update the missileCount variable
			setNumberOfTries();
			
		}
		
	}
	
	// Use this for initialization
	void Start () {

		// instantiate new GameObject
		cannon = new GameObject();

		// associate the 'cannon' GameObject with the 'Launcher' GameObject
		cannon = GameObject.Find("MissileLauncher");
		
		
	}
	
	// Update is called once per frame
	void Update () {

		// update the GUI textfield with the current missileCount
		missileCount = numberOfMissiles.ToString();
	}
	

	// method to increment the missile count
	public void setNumberOfTries(){
		
		numberOfMissiles = numberOfMissiles + 1;
		
	}
}
