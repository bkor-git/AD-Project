using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylinder : MonoBehaviour
{
    public bool goToEnd = false;

    public GameObject obstacle;
    GameObject[] agents;
    GameObject[] wanders;
    float timeInSeconds; // Change to float for time in seconds
    Vector3 position;


    void Start()
    {
        Time.timeScale = 1.0f;
        agents = GameObject.FindGameObjectsWithTag("Avatars");
        wanders = GameObject.FindGameObjectsWithTag("Wander");
        timeInSeconds = 24.0f; // Set to the desired time in seconds
        position = new Vector3(Random.Range(30, 32), 0.2f, Random.Range(-10, 10));
    }

    void Update()
    {
        // Compare Time.time (total time in seconds) with the desired time to instantiate
        if (Time.time >= timeInSeconds)
        {
            // Reset timeInSeconds to avoid repeated instantiations
            timeInSeconds = float.MaxValue;

            // Instantiate the obstacle
            Instantiate(obstacle, position, Quaternion.identity);

            // Notify agents and wanderers of the new obstacle
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
