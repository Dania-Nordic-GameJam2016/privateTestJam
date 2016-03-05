using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    float timer = 10.0f;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 0;


            StartCoroutine(EndGame());
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 30, 20), "" + timer.ToString("0"));
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
