using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{

    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator anim;
    float speedMult;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        goalLocations = GameObject.FindGameObjectsWithTag("TrainDoor");
        int i = Random.Range(0, goalLocations.Length);
        agent.SetDestination(goalLocations[i].transform.position);
        anim = this.GetComponent<Animator>();
        ResetAgent();
    }

    void ResetAgent()
    {
        speedMult = Random.Range(0.1f, 1.5f);
        anim.SetFloat("speedMult", speedMult);
        agent.speed *= speedMult;
        anim.SetTrigger("isWalking");
        agent.angularSpeed = 120.0f;
        agent.ResetPath();
    }

    void Update()
    {

        if (agent.remainingDistance < 1.0f)
        {

            ResetAgent();
            int i = Random.Range(0, goalLocations.Length);
            agent.SetDestination(goalLocations[i].transform.position);
        }
    }
}