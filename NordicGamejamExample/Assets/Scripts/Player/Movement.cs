using UnityEngine;
using System.Collections;

public enum Players
{
    player1,
    player2,
    player3,
    player4
}

public class Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody body;
    [SerializeField]
    KeyCode runKey;
    [SerializeField]
    KeyCode altRunKey;
    [SerializeField]
    public float rotationSpeed = 1.8f;
    [SerializeField]
    Players player;
    string horizontal;
    string vertical;
    public bool Imdead { get; set; }
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();

        switch (player)
        {
            case Players.player1:
                horizontal = "HorizontalP1";
                vertical = "VerticalP1";
                transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                break;
            case Players.player2:
                horizontal = "HorizontalP2";
                vertical = "VerticalP2";
                transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                break;
            case Players.player3:
                horizontal = "HorizontalP3";
                vertical = "VerticalP3";
                transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 0.5f);
                break;
            case Players.player4:
                horizontal = "HorizontalP4";
                vertical = "VerticalP4";
                transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
                break;
            default:
                break;
        }
        GameObject.Find("GameManager").GetComponent<InactiveManager>().Players.Add(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Imdead)
        {
            if (Input.GetAxis(vertical) > 0)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
            if (Input.GetAxis(vertical) < 0)
            {
                animator.SetBool("isReversing", true);
            }
            else
            {
                animator.SetBool("isReversing", false);
            }
            if ((Input.GetKey(runKey) || Input.GetKey(altRunKey)) && Input.GetAxis(vertical) > 0)
            {
                animator.SetBool("run", true);
                rotationSpeed = 1.8f;
            }
            else
            {
                animator.SetBool("run", false);
                rotationSpeed = 4;
            }

            transform.Rotate(new Vector3(0, Input.GetAxis(horizontal) * rotationSpeed, 0));
        }
    }
}
