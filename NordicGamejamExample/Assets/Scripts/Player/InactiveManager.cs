using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InactiveManager : MonoBehaviour
{
    public List<GameObject> Workers { get; set; }
    public List<GameObject> Walls { get; set; }
    public List<GameObject> Players { get; set; }
    public List<GameObject> Agents { get; set; }
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
        bool endGame = true;
        foreach (GameObject item in Players)
        {
            if (!item.GetComponent<Movement>().Imdead)
            {
                endGame = false;

            }
        }

        if (endGame)
        {
            StartCoroutine(Players[0].GetComponent<Caught>().DeathtTimer());
        }
    }
}
