using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInit : MonoBehaviour {
	public bool vr = false;
	// Use this for initialization
	void Start () {
        UnityEngine.VR.VRSettings.enabled = vr;
        Debug.Log(UnityEngine.VR.VRSettings.enabled);

		Display[] displays = Display.displays;
		if (displays.Length > 1 && !vr) {
			displays [1].Activate (1920, 1080, 60);
			displays [2].Activate (1920, 1080, 60);
			displays [3].Activate (1920, 1080, 60);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0;i < 20; i++) {
             if(Input.GetKeyDown("joystick 1 button "+i)){
                 print("joystick 1 button "+i);
             }
         }
	}
}
