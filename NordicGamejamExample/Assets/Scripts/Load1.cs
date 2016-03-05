using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load1 : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {

            SceneManager.LoadSceneAsync("Scene1", LoadSceneMode.Additive);
            //SceneManager.UnloadScene("Scene6");
        }

    }
}
