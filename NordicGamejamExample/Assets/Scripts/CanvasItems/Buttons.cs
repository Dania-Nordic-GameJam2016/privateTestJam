using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("level");
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        //        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
