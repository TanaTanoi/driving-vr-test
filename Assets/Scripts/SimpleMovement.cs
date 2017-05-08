using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

	public Camera leftCamera;
	public Camera RightCamera;
	public Camera frontCamera;

	private bool moving = true;
	private float ticker = 0;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float userHoz = Input.GetAxis ("Horizontal");
		float hoz = Mathf.Sin(ticker);
		float ver = Mathf.Cos (ticker);
		if (moving) {
			ticker += 0.02f;
		}
		transform.position += new Vector3(userHoz, 0,0);

		bool left_bracket_down = Input.GetKey (KeyCode.Comma);
		bool right_bracket_down = Input.GetKey (KeyCode.Period);

		if (left_bracket_down) {
			ticker += 0.02f;
		}
		if (right_bracket_down) {
			ticker -= 0.02f;
		}

		bool left_pressed = Input.GetKeyDown (KeyCode.A);
		bool right_pressed = Input.GetKeyDown (KeyCode.D);
		bool up_pressed = Input.GetKeyDown (KeyCode.W);
		bool down_pressed = Input.GetKeyDown (KeyCode.S);
		bool space_pressed = Input.GetKeyDown (KeyCode.Space);

		bool up_arrow_pressed = Input.GetKeyDown (KeyCode.UpArrow);
		bool down_arrow_pressed = Input.GetKeyDown (KeyCode.DownArrow);

		bool y_pressed = Input.GetKeyDown (KeyCode.Y); // viewport y up
		bool u_pressed = Input.GetKeyDown (KeyCode.U); // viewport y down
		bool h_pressed = Input.GetKeyDown (KeyCode.H); // viewport height up
		bool j_pressed = Input.GetKeyDown (KeyCode.J); // viewport height down

		if (left_pressed) {
			leftCamera.transform.localPosition -= new Vector3 (0.1f, 0, 0);
			RightCamera.transform.localPosition += new Vector3 (0.1f, 0, 0);
		}

		if (right_pressed) {
			leftCamera.transform.localPosition += new Vector3 (0.1f, 0, 0);
			RightCamera.transform.localPosition -= new Vector3 (0.1f, 0, 0);
		}

		if (up_pressed) {
			//leftCamera.transform.localPosition += new Vector3 (0, 0, 0.1f);
			//RightCamera.transform.localPosition += new Vector3 (0, 0, 0.1f);
            transform.position += Vector3.up* 0.1f;
		}

		if (down_pressed) {

            //leftCamera.transform.localPosition -= new Vector3 (0, 0, 0.1f);
            //RightCamera.transform.localPosition -= new Vector3 (0, 0, 0.1f);;
            transform.position += Vector3.down * 0.1f;
		}

		if (up_arrow_pressed) {
			frontCamera.fieldOfView++;
		}

		if (down_arrow_pressed) {
			frontCamera.fieldOfView--;
		}

		if (y_pressed) {
			Rect curr = frontCamera.rect;
			frontCamera.rect = new Rect (curr.position + new Vector2 (0, 0.02f), curr.size);
		}
		if (u_pressed) {
			Rect curr = frontCamera.rect;
			frontCamera.rect = new Rect (curr.position - new Vector2 (0, 0.02f), curr.size);
		}

		if (h_pressed) {
			Rect curr = frontCamera.rect;
			frontCamera.rect = new Rect (curr.position, curr.size  + new Vector2 (0, 0.02f));
		}
		if (j_pressed) {
			Rect curr = frontCamera.rect;
			frontCamera.rect = new Rect (curr.position, curr.size - new Vector2 (0, 0.02f));
		}

		if (space_pressed) {
			moving = !moving;
		}
	}
	void OnGUI() {
		string text = "side cam pos : " + leftCamera.transform.localPosition +"\n";
		      text += "main cam fov : " + frontCamera.fieldOfView + "\n";
		      text += "main cam rect: " + frontCamera.rect;
			
		GUI.Label (new Rect (0, 0, Screen.width, Screen.height), text);
	}
}
