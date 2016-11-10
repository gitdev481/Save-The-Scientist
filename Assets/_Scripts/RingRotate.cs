﻿using UnityEngine;
using System.Collections;

public class RingRotate : MonoBehaviour {

	public float rotateSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0.0f, 0.0f, rotateSpeed * Time.deltaTime);
	}
}
