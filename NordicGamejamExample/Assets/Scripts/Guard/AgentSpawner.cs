using UnityEngine;
using System.Collections;

public class AgentSpawner : MonoBehaviour
{
    GameObject agents;
    public GameObject agt;
    [SerializeField]
    private GameObject agentPrefab;
    [SerializeField]
    private GameObject agentElitePrefab;
    public float timer = 30;
    private float nextAgent;
    int agentIndex = 0;
    int randomModulosFactor;

    void Start()
    {
        agents = GameObject.Find("Agents");
    }

    void Update()
    {
        if (Time.fixedTime > nextAgent)
        {
            randomModulosFactor = Random.Range(4, 8);
            nextAgent = Time.fixedTime + timer;

            if (agentIndex % randomModulosFactor == 0 && agentIndex != 0)
            {
                //agents = Instantiate(agentElitePrefab) as GameObject;
                agents = Instantiate(agentElitePrefab, transform.position, Quaternion.identity) as GameObject;
            }
            else
            {
                //agents = Instantiate(agentPrefab) as GameObject;
                agents = Instantiate(agentPrefab, transform.position, Quaternion.identity) as GameObject;

            }

            agents.name = "Agent " + agentIndex;
            agentIndex++;
            agents.transform.parent = agt.transform;
            agents.transform.position = this.transform.position;
        }
    }


}
