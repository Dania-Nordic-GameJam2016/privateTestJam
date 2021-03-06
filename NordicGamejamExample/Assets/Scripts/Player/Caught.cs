﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Caught : MonoBehaviour
{
    Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    GotCaught();
        //}

    }

    /// <summary>
    /// Use this when you get caught
    /// </summary>
    public void GotCaught()
    {
        if (GlobalCommunicator.numberOfPlayers == 1)
        {
            animator.SetTrigger("death");
            GetComponent<Movement>().Imdead = true;
            StartCoroutine(DeathtTimer());
        }
        else
        {
            animator.SetTrigger("death");
            GetComponent<Movement>().Imdead = true;
            StartCoroutine(ActualDeathtTimer());
        }
    }

    public IEnumerator DeathtTimer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");

    }

    public IEnumerator ActualDeathtTimer()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("GameManager").GetComponent<InactiveManager>().Players.Remove(gameObject);
        Destroy(gameObject);
    }
}
