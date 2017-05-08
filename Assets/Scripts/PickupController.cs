using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour {

    private Pickup[] items;

    void Start () {
        items = GameObject.FindObjectsOfType<Pickup>();
	}

    public float Progress() {
        int count = 0;
        foreach(Pickup p in items) {
            count = p.Activated() ? count + 1 : count;
        }
        return count / (float)items.Length;
    }	
}
