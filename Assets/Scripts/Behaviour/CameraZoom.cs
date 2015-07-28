using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    float fov;
	// Use this for initialization
	void Start () {
        fov = Camera.main.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Zoom Camera"))
        {
            Camera.main.fieldOfView = 20;
        }
        else if(Input.GetButtonUp("Zoom Camera"))
        {
            Camera.main.fieldOfView = fov;
        }
	}
}
