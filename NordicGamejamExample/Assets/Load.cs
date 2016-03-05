using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Load : MonoBehaviour
{


    private bool loadScene = false;

    public bool LoadScene
    {
        get
        {
            return loadScene;
        }

        set
        {
            loadScene = value;
        }
    }

    
    // Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            
            SceneManager.LoadSceneAsync("Scene6", LoadSceneMode.Additive);
        }

    }
}
