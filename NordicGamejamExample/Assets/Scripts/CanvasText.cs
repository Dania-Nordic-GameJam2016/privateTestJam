using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //GetComponent<CanvasText>().
        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "";
        //gameObject.i
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (GameObject.Find("GameOverCheckPoint").GetComponent<GameOverCheck>().GameOver)
        {
            //gameObject.SetActive(true);
            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "You won!";
        }

    }
}
