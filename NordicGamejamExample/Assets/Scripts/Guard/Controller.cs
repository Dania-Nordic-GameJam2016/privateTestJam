using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    Camera viewCamera;
    PathSelection path;
    public float movementSpeed = 6;

	void Start () {
        viewCamera = Camera.main;
        path = GetComponent<PathSelection>();
	}
	
	void Update () {
        KeyboardInput();
    }

    void LookAtMousePosition()
    {
        Vector3 mousePosition = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        transform.LookAt(mousePosition + Vector3.up * transform.position.y);
    }

    void KeyboardInput()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        transform.position += movement;
    }
}
