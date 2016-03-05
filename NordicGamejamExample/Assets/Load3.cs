using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load3 : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {

            SceneManager.LoadSceneAsync("Scene3", LoadSceneMode.Additive);
            SceneManager.UnloadScene("Scene4");
        }

    }
}
