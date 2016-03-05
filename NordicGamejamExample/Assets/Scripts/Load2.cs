using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load2 : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {

            SceneManager.LoadSceneAsync("Scene2", LoadSceneMode.Additive);
            SceneManager.UnloadScene("Scene5");
        }

    }
}
