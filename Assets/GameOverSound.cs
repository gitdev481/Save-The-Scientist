using UnityEngine;
using System.Collections;

public class GameOverSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<AudioSource>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
