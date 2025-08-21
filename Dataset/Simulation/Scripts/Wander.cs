using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;
    Animator anim;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        anim= this.GetComponent<Animator>();
        anim.SetFloat("wOffset", Random.Range(0.0f, 1.0f));
        anim.SetTrigger("isWalking");
        agent.angularSpeed = 120.0f;
        timer = wanderTimer;
    }

    void ResetAgent()
    {
        anim.SetTrigger("isWalking");
        agent.angularSpeed = 120.0f;
        agent.ResetPath();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(agent.transform.position, wanderRadius, -1);
            ResetAgent();
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
