using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("MenuForPlayer");
    }

    public void StartGame1P()
    {
        GlobalCommunicator.numberOfPlayers = 1;
        SceneManager.LoadScene("level");
    }

    public void StartGame2P()
    {
        GlobalCommunicator.numberOfPlayers = 2;
        SceneManager.LoadScene("level");
    }

    public void StartGame3P()
    {
        GlobalCommunicator.numberOfPlayers = 3;
        SceneManager.LoadScene("level");
    }

    public void StartGame4P()
    {
        GlobalCommunicator.numberOfPlayers = 4;
        SceneManager.LoadScene("level");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
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
