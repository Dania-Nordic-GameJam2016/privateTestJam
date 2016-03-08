using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InactiveManager : MonoBehaviour
{
    public List<GameObject> Workers { get; set; }
    public List<GameObject> Walls { get; set; }
    public List<GameObject> Players { get; set; }
    public List<GameObject> Agents { get; set; }
    public Text winnerText;
    float timer;
    // Use this for initialization
    void Awake()
    {
        Workers = new List<GameObject>();
        Walls = new List<GameObject>();
        Players = new List<GameObject>();
        Agents = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            foreach (GameObject player in Players)
            {
                foreach (GameObject item in Workers)
                {
                    float dist = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - item.transform.position.x, 2) + Mathf.Pow(player.transform.position.z - item.transform.position.z, 2));
                    if (dist > 20)
                    {
                        item.SetActive(false);
                    }
                    else if (!item.activeInHierarchy)
                    {
                        item.SetActive(true);
                    }
                    if (dist < 2)
                    {
                        GameObject nearest = null;
                        float lastDist = 9999;
                        foreach (GameObject agent in Agents)
                        {
                            List<GameObject> l = GetComponent<InactiveManager>().Players;
                            Movement mov = item.GetComponent<Movement>();
                            float distToClosestAgent = Mathf.Sqrt(Mathf.Pow(agent.transform.position.x - item.transform.position.x, 2) + Mathf.Pow(agent.transform.position.z - item.transform.position.z, 2));

                            if (distToClosestAgent < lastDist)
                            {
                                nearest = agent;
                                lastDist = distToClosestAgent;
                            }
                        }
                        if (nearest != null)
                        {
                            nearest.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
                        }
                    }
                }

                foreach (GameObject item in Walls)
                {
                    float dist = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - item.transform.position.x, 2) + Mathf.Pow(player.transform.position.z - item.transform.position.z, 2));
                    if (dist > 30)
                    {
                        item.SetActive(false);
                    }
                    else if (!item.activeInHierarchy)
                    {
                        item.SetActive(true);
                    }
                }
            }
            timer = 3;
        }

        if (Players.Count <= 1 && GlobalCommunicator.numberOfPlayers > 1)
        {
            string gameWinner = "";
            float widthPlayerOne = Screen.width * 0.25f;
            float widthPlayerTwo = Screen.width * 0.75f;
            float heightPlayerTwo = Screen.height * 0.75f;
            if (GlobalCommunicator.numberOfPlayers == 2)
            {
                widthPlayerOne = Screen.width * 0.5f;
                widthPlayerTwo = Screen.width * 0.5f;
                heightPlayerTwo = Screen.height * 0.25f;
            }
            switch (Players[0].GetComponent<Movement>().player)
            {
                case global::Players.player1:
                    winnerText.transform.position = new Vector3(widthPlayerOne, Screen.height * 0.75f);
                    gameWinner = "Player 1";
                    break;
                case global::Players.player2:
                    winnerText.transform.position = new Vector3(widthPlayerTwo, heightPlayerTwo);
                    gameWinner = "Player 2";
                    break;
                case global::Players.player3:
                    winnerText.transform.position = new Vector3(Screen.width * 0.25f, Screen.height * 0.25f);
                    gameWinner = "Player 3";
                    break;
                case global::Players.player4:
                    gameWinner = "Player 4";
                    winnerText.transform.position = new Vector3(Screen.width * 0.75f, Screen.height * 0.25f);
                    break;
                default:
                    break;
            }

            winnerText.GetComponent<Text>().text = gameWinner + " won the game!";

            StartCoroutine(Players[0].GetComponent<Caught>().DeathtTimer());
        }
        else if (Players.Count <= 0)
        {
            StartCoroutine(Players[0].GetComponent<Caught>().DeathtTimer());
        }
    }
}
