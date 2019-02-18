using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {


    // Use this for initialization
    void Start () {
		
	}



	// Update is called once per frame
	void Update () {
        float prevScroll = 0f;
        float panSpeed = 40;


        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.LeftShift)) {
            panSpeed = 80;
        }
		if (Input.GetKey("w")) {
			pos.z += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey("s")) {
			pos.z -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey("a")) {
			pos.x -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey("d")) {
			pos.x += panSpeed * Time.deltaTime;
		}
		if (Input.GetAxis("Mouse ScrollWheel") < prevScroll) {
            prevScroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y += 2 * panSpeed * Time.deltaTime;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > prevScroll) {
            prevScroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y -= 2 * panSpeed * Time.deltaTime;
		}

		transform.position = pos;
	}
}
