using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Load5 : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            
            SceneManager.LoadSceneAsync("Scene5", LoadSceneMode.Additive);
        }

    }
}
