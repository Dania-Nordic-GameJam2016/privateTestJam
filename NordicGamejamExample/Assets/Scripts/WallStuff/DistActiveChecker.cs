using UnityEngine;
using System.Collections;

public class DistActiveChecker : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        try
        {
            GameObject.Find("Player").GetComponent<InactiveManager>().Walls.Add(gameObject);
        }
        catch (System.Exception)
        {
            Debug.Log("Missing player");
        }
    }
}
