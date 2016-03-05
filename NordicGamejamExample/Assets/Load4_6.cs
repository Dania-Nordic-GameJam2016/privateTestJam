using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load4_6 : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadSceneAsync("Scene4", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("Scene6", LoadSceneMode.Additive);
            SceneManager.UnloadScene("Scene3");
            SceneManager.UnloadScene("Scene1");
        }

    }

}
