using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCheck : MonoBehaviour {
    
    bool gameOver = false;

    public bool GameOver
    {
        get
        {
            return gameOver;
        }

        set
        {
            gameOver = value;
        }
    }

    void Start()
    {
        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            gameOver = true;
            EndGameTriggerStuff();
        }

    }

    /// <summary>
    /// Skriver winning text på canvas, når spilleren trigger box collideren på EndGameTrigger
    /// </summary>
    public void EndGameTriggerStuff()
    {
        if (GameObject.Find("EndGameTrigger").GetComponent<GameOverCheck>().GameOver)
        {
            //gameObject.SetActive(true);
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "You won! :-)";
            StartCoroutine(EndGame());
        }
    }

    /// <summary>
    /// Venter 5 sekunder før den kører Menu scenen. 
    /// </summary>
    /// <returns></returns>
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
