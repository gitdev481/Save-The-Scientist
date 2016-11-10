using UnityEngine;
using System.Collections;

public class MissileLauncher : MonoBehaviour {


	public GameObject missile;
    public AudioSource rocketFire;


	void Update () {

		if (Input.GetMouseButtonDown(0)) { 
	
		}

	
	}

    public void FireMissile()
    {
        rocketFire.Play();
        Vector3 position = new Vector3(0f, 0.09f, 0f) * 10.0f;
        position = transform.TransformPoint(position);
        GameObject thisMissile = Instantiate(missile, position, transform.rotation) as GameObject;
        Physics.IgnoreCollision(thisMissile.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
