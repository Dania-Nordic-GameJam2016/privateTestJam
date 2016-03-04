using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    Camera viewCamera;

	void Start () {
        viewCamera = Camera.main;
	}
	
	void Update () {
        LookAtMousePosition();
    }

    void LookAtMousePosition()
    {
        Vector3 mousePosition = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        transform.LookAt(mousePosition + Vector3.up * transform.position.y);
    }
}
