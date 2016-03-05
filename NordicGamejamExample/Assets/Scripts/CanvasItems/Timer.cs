using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timer = 10.0f;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 0;
            //GameObject.Find("Canvas/Text").GetComponent<Text>().text = "GameOver!";
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 50, 20), "" + timer.ToString("0"));
    }
}
