using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyCam : MonoBehaviour {

    public float deadzone = 0.0001f;

    private Transform cam;
    private Vector3 position;
	void Start () {
        cam = transform.GetChild(0);
        position = cam.position;
	}
	
	void FixedUpdate () {
        cam.position = position;
        position -= (position - transform.position) * 0.1f;

	}
}
