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
    public Players player;
    string horizontal;
    string vertical;
    public bool Imdead { get; set; }
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        GameObject.Find("GameManager").GetComponent<InactiveManager>().Players.Add(gameObject);


        switch (GlobalCommunicator.numberOfPlayers)
        {
            case 1:
                horizontal = "HorizontalP1";
                vertical = "VerticalP1";
                transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
                foreach (GameObject player in GameObject.Find("GameManager").GetComponent<InactiveManager>().Players)
                {
                    if (player.GetComponent<Movement>().player != Players.player1)
                    {
                        GameObject.Find("GameManager").GetComponent<InactiveManager>().Players.Remove(player);
                        Destroy(player);
                        player.SetActive(false);
                    }
                }
                break;
            case 2:
                Pretty2P();
                foreach (GameObject player in GameObject.Find("GameManager").GetComponent<InactiveManager>().Players)
                {
                    if (player.GetComponent<Movement>().player != Players.player1 && player.GetComponent<Movement>().player != Players.player2)
                    {
                        GameObject.Find("GameManager").GetComponent<InactiveManager>().Players.Remove(player);
                        Destroy(player);
                        player.SetActive(false);
                    }
                }
                break;
            case 3:
                Pretty3P();
                foreach (GameObject player in GameObject.Find("GameManager").GetComponent<InactiveManager>().Players)
                {
                    if (player.GetComponent<Movement>().player == Players.player4)
                    {
                        GameObject.Find("GameManager").GetComponent<InactiveManager>().Players.Remove(player);
                        Destroy(player);
                        player.SetActive(false);
                    }
                }
                break;
            case 4:
                Pretty4P();
                break;
            default:
                break;
        }

        
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
                rotationSpeed = 2.5f;
            }
            else
            {
                animator.SetBool("run", false);
                rotationSpeed = 4;
            }

            transform.Rotate(new Vector3(0, Input.GetAxis(horizontal) * rotationSpeed, 0));
        }
    }

    void Pretty2P()
    {
        switch (player)
        {
            case Players.player1:
                horizontal = "HorizontalP1";
                vertical = "VerticalP1";
                transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
                break;
            case Players.player2:
                horizontal = "HorizontalP2";
                vertical = "VerticalP2";
                transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                break;
            default:
                break;
        }

    }

    void Pretty3P()
    {
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
            default:
                break;
        }
    }

    void Pretty4P()
    {
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
    }
}
