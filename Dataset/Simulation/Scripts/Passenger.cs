using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Random = UnityEngine.Random;
public class Passenger : MonoBehaviour
{ 
    private bool reachedEntranceDoor = false;
    private bool reachedTrainDoor = false;
    GameObject[] trainDoors;
    GameObject[] entrances;
    GameObject ePoint;
    Animator anim;
    GameObject exit;
    NavMeshAgent agent;
    private float closeEnough = 0.5f;

    private void Update()
    {
        if (GameObject.FindObjectOfType<DropCylinder>().goToEnd)
        { 
            agent.SetDestination(ePoint.transform.position);
            anim.SetTrigger("isRunning");
            agent.speed = Random.Range(9, 10);
            agent.angularSpeed = 500.0f;
            
            if (Mathf.Abs(agent.transform.position.x - ePoint.transform.position.x) <= closeEnough || Mathf.Abs(agent.transform.position.z - ePoint.transform.position.z) <= closeEnough)
            {
                Renderer[] lChildRenderers = agent.GetComponentsInChildren<Renderer>();
                foreach (Renderer lRenderer in lChildRenderers)
                {
                    lRenderer.enabled = false;
                }
            }
            
        }
  
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        trainDoors = GameObject.FindGameObjectsWithTag("TrainDoor");
        entrances = GameObject.FindGameObjectsWithTag("Entrance");
        ePoint = GameObject.FindGameObjectWithTag("EPoint");
        exit = GameObject.FindGameObjectWithTag("Exit");
        agent.SetDestination(entrances[Random.Range(0, entrances.Length)].transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("wOffset", Random.Range(0.0f, 1.0f));
        anim.SetTrigger("isWalking");
        agent.angularSpeed = 120.0f;
    }


    void ResetAgent()
    {
        anim.SetTrigger("isWalking");
        agent.angularSpeed = 120.0f;
        agent.ResetPath();
    }

    public void DetectNewObstacle(Vector3 position)
    {
        agent.SetDestination(ePoint.transform.position);
        anim.SetTrigger("isRunning");
        agent.speed = Random.Range(9, 10);
        agent.angularSpeed = 500.0f;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (!GameObject.FindObjectOfType<DropCylinder>().goToEnd)
        {
            if (collider.tag.Equals("Entrance"))
            {
                reachedEntranceDoor = true;
                ResetAgent();
                agent.SetDestination(trainDoors[Random.Range(0, trainDoors.Length)].transform.position);
            }

            if (collider.tag.Equals("TrainDoor"))
            {
                reachedTrainDoor = true;
                StartCoroutine(waitForTrainDoor());
            }

            if (collider.tag.Equals("Exit"))
            {
                ResetAgent();
                agent.SetDestination(ePoint.transform.position);
            }
            
            if (collider.tag.Equals("EPoint"))
            {
                Renderer[] lChildRenderers = agent.GetComponentsInChildren<Renderer>();
                foreach (Renderer lRenderer in lChildRenderers)
                {
                    lRenderer.enabled = false;
                }
               
            }
            
        }
        
    }

    public bool hasReachedEntranceDoor()
    {
        return reachedEntranceDoor;
    }

    public bool hasReachedTrainDoor()
    {
        return reachedTrainDoor;
    }



    IEnumerator waitForTrainDoor()
    {
        
        yield return new WaitForSeconds(0.01f);
        if (!GameObject.FindObjectOfType<DropCylinder>().goToEnd)
        {
            ResetAgent();
            agent.SetDestination(exit.transform.position);
        }
        
    }
}
