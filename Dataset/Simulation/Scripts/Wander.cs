using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    Animator anim;
    private NavMeshAgent agent;
    private float timer;
    private GameObject ePoint; 

    private void Start()
    {
        ePoint = GameObject.FindGameObjectWithTag("EPoint");
    }

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
            if (!GameObject.FindObjectOfType<DropCylinder>().goToEnd)
            {
                Vector3 newPos = RandomNavSphere(agent.transform.position, wanderRadius, -1);
                ResetAgent();
                agent.SetDestination(newPos);
                timer = 0;
            }
            if (GameObject.FindObjectOfType<DropCylinder>().goToEnd)
            { 
                agent.SetDestination(ePoint.transform.position);
                anim.SetTrigger("isRunning");
                agent.speed = Random.Range(9, 10);
                agent.angularSpeed = 500.0f;
                if (Mathf.Abs(agent.transform.position.x - ePoint.transform.position.x) <= 1.0f && Mathf.Abs(agent.transform.position.z - ePoint.transform.position.z) <= 1.0f)
                {
                    Renderer[] lChildRenderers = agent.GetComponentsInChildren<Renderer>();
                    foreach (Renderer lRenderer in lChildRenderers)
                    {
                        lRenderer.enabled = false;
                    }
                }
            }
        }
    }

    public void DetectNewObstacle(Vector3 position)
    { 
        agent.SetDestination(ePoint.transform.position);
        anim.SetTrigger("isRunning");
        agent.speed = Random.Range(9, 10);
        agent.angularSpeed = 500.0f;
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
