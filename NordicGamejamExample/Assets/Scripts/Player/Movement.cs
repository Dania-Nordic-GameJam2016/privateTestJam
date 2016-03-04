﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody body;
    [SerializeField]
    KeyCode runKey;
    [SerializeField]
    KeyCode altRunKey;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if ((Input.GetKey(runKey) || Input.GetKey(altRunKey)) && Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0));
    }
}
