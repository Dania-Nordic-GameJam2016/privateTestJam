using UnityEngine;
using System.Collections;

public enum Role
{
    standardMand,
    assHoleMand
}
public class MovementForMedarbejdere : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    float timer;
    bool newMove = false;
    public Role Rolle { get; set; }
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        GameObject.Find("Player").GetComponent<InactiveManager>().Workers.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (agent.remainingDistance > 0.5f)
        {
            animator.SetBool("walk", true);
        }
        else if (timer <= 0)
        {
            animator.SetBool("walk", false);
            timer = Random.Range(0, 6);
        }


        if (timer > 0)
        {
            timer -= Time.deltaTime;
            newMove = true;
        }
        if (newMove && timer <= 0)
        {
            Vector3 v3 = transform.position + new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
            agent.SetDestination(v3);
            newMove = false;
        }


    }
}
