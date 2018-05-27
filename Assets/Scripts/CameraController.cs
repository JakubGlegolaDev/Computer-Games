using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 5f;
	public float minY = 5f;
	public float maxY = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.GameIsOver) {
			this.enabled = false;
			return;
		}

		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);

		}

		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThickness) {
			transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);

		}

		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThickness) {
			transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);

		}

		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);

		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		// negative number may cause bugs, so write in hard codes
		pos.x = Mathf.Clamp (pos.x + 10f, 0f, 25f) - 10f;
		pos.z = Mathf.Clamp (pos.z + 15f, 0f, 15f) - 15f;

		transform.position = pos;
	}
}
