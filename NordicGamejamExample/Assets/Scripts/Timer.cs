using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    float timer = 10.0f;

    void Update()
    {
        timer -= Time.deltaTime;
    }
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 50, 20), "" + timer.ToString("0"));
    }
}
