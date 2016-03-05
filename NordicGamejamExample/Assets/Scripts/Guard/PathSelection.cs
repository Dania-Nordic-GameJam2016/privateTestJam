using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathSelection : MonoBehaviour
{
    private GameObject waypoints;
    private GameObject manager;
    private List<Transform> kids;
    private int children;
    public int patrolIndex = 0;
    public int[] patrol;
    public int[] mypath;
    private bool pathChosen = false;

    void Start()
    {
        patrol = new int[0];
        kids = new List<Transform>();
        waypoints = GameObject.Find("Waypoints");
        manager = GameObject.Find("Game Manager");
        children = waypoints.transform.childCount;
        ExposeChildren();
    }

    void Update()
    {
        if (manager.GetComponent<WaypointList>().imReady)
        {
            if (pathChosen)
            {
                ChooseNode();
            }
            else
            {
                ChoosePatrol();
                pathChosen = true;
            }
        }

    }

    void ExposeChildren()
    {
        for (int i = 0; i < children; i++)
        {
            kids.Add(waypoints.transform.GetChild(i));
        }
    }

    void ChoosePatrol()
    {
        int random = (int)Mathf.Round(Random.Range(0, 1));
        float distanceToChild0 = Vector3.Distance(transform.position, waypoints.transform.GetChild(0).position);
        float distanceToChild5 = Vector3.Distance(transform.position, waypoints.transform.GetChild(5).position);
        float distanceToChild12 = Vector3.Distance(transform.position, waypoints.transform.GetChild(12).position);
        float distanceToChild17 = Vector3.Distance(transform.position, waypoints.transform.GetChild(17).position);

        if (distanceToChild0 < distanceToChild5 && distanceToChild0 < distanceToChild12 && distanceToChild0 < distanceToChild17)
        {
            if (random == 0)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol1.Length];
                patrol = manager.GetComponent<WaypointList>().patrol1;
            }
            if (random == 1)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol2.Length];
                patrol = manager.GetComponent<WaypointList>().patrol2.Clone() as int[];
            }
        }
        if (distanceToChild5 < distanceToChild0 && distanceToChild5 < distanceToChild12 && distanceToChild5 < distanceToChild17)
        {
            if (random == 0)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol3.Length];
                patrol = manager.GetComponent<WaypointList>().patrol3.Clone() as int[];
            }
            if (random == 1)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol4.Length];
                patrol = manager.GetComponent<WaypointList>().patrol4.Clone() as int[];
            }
        }
        if (distanceToChild12 < distanceToChild0 && distanceToChild12 < distanceToChild5 && distanceToChild12 < distanceToChild17)
        {
            if (random == 0)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol5.Length];
                patrol = manager.GetComponent<WaypointList>().patrol5.Clone() as int[];
            }
            if (random == 1)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol6.Length];
                patrol = manager.GetComponent<WaypointList>().patrol6.Clone() as int[];
            }
        }
        if (distanceToChild17 < distanceToChild0 && distanceToChild17 < distanceToChild5 && distanceToChild17 < distanceToChild12)
        {
            if (random == 0)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol7.Length];
                patrol = manager.GetComponent<WaypointList>().patrol7.Clone() as int[];
            }
            if (random == 1)
            {
                patrol = new int[manager.GetComponent<WaypointList>().patrol8.Length];
                patrol = manager.GetComponent<WaypointList>().patrol8.Clone() as int[];
            }
        }
    }

    void ChooseNode()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints.transform.GetChild(patrol[patrolIndex]).position, 5 * Time.deltaTime);
        float dist = Mathf.Sqrt(Mathf.Pow(transform.position.x - waypoints.transform.GetChild(patrol[patrolIndex]).position.x, 2) + Mathf.Pow(transform.position.z - waypoints.transform.GetChild(patrol[patrolIndex]).position.z, 2));
        Vector3 target = waypoints.transform.GetChild(patrol[patrolIndex]).position - transform.position;
        target.y = 0;
        Quaternion rotation = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 7);

        if (dist < 0.5f)
        {
            patrolIndex++;
        }

        if (patrolIndex == kids.Count - 1)
        {
            patrolIndex = 0;
        }
    }
}
