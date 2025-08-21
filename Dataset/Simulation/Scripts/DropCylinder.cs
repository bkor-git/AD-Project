/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropCylinder : MonoBehaviour
{
    public bool goToEnd = false;

    public GameObject obstacle;
    GameObject[] agents;
    GameObject[] wanders;
    int time;
    Vector3 position;
    void Start()
    {

        agents = GameObject.FindGameObjectsWithTag("Player");
        wanders = GameObject.FindGameObjectsWithTag("wander");
        time = Random.Range(30000, 30500);
        position = new Vector3(Random.Range(15, 40), 0.5f, Random.Range(-30, 0));
    }


    void Update()
    {


        if (Time.frameCount == time)
        {
            time = 0;
            Instantiate(obstacle, position, Quaternion.identity);

            foreach (GameObject agent in agents)
            {
                goToEnd = true;
                agent.GetComponent<Passenger>().DetectNewObstacle(obstacle.transform.position);
            }

            foreach (GameObject wander in wanders)
            {
                goToEnd = true;
                wander.GetComponent<Wander>().DetectNewObstacle(obstacle.transform.position);
            }
            

        }


    }
}
*/
