using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Loadinglevel());

    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Loadinglevel()
    {
        SceneManager.LoadSceneAsync("Scene6", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync("Workers", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("Scene3", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("Scene2", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.2f); 
        //yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Scene1", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        //yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Scene5", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        //yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("AgentScene1", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        //yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("Scene4", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        //yield return new WaitForSeconds(3);
    }
}
