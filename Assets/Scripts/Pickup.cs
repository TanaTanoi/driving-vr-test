using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private bool activated;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Activate();
        }
    }

    public void Activate() {
        Debug.Log("aw yis");
        activated = true;
    }

    public bool Activated() {
        return activated;
    }
}
