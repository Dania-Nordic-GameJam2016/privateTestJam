using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointList : MonoBehaviour
{
    private GameObject waypoints;
    public bool imReady = false;

    public int children;
    public int[] patrol1;
    public int[] patrol2; 
    public int[] patrol3; 
    public int[] patrol4; 
    public int[] patrol5; 
    public int[] patrol6; 
    public int[] patrol7; 
    public int[] patrol8;     

    void Start()
    {
        patrol1 = new int[] { 0, 6, 12, 13, 14, 8, 9, 3, 2, 8, 14, 15, 16, 10, 9, 3, 2, 1, 0 };
        patrol3 = new int[] { 5, 11, 17, 16, 15, 9, 8, 2, 3, 4, 10, 16, 15, 9, 3, 4, 5 };
        patrol4 = new int[] { 5, 4, 3, 9, 8, 7, 13, 14, 15, 9, 10, 11, 5 };
        patrol5 = new int[] { 12, 13, 7, 6, 0, 1, 2, 3, 9, 10, 11, 5, 4, 3, 9, 15, 14, 13, 12 };
        patrol6 = new int[] { 12, 6, 0, 1, 2, 3, 9, 15, 16, 17, 11, 5, 4, 3, 9, 8, 2, 1, 0, 6, 12 };
        patrol7 = new int[] { 17, 16, 15, 9, 8, 2, 1, 0, 6, 7, 13, 14, 8, 2, 3, 4, 5, 12, 17 };
        patrol8 = new int[] { 17, 11, 10, 4, 5, 6, 11, 10, 16, 15, 14, 13, 7, 6, 0, 1, 7, 8, 9, 15, 16, 17 };
        waypoints = GameObject.Find("Waypoints");
        children = waypoints.transform.childCount;
        imReady = true;
    }
}
