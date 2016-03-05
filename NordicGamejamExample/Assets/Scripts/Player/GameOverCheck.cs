using UnityEngine;
using System.Collections;

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

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            Debug.Log("You won!");
            gameOver = true;
            Debug.Log("Check");
        }

    }
}
