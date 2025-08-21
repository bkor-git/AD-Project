using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoissonArrival : MonoBehaviour
{
    public GameObject myPassenger;
    float xPos;
    float zPos;
    float scale;
    int passengerCount = 0;
    int i;
    public float lambdaVal;
    public int eventVal;

    public List<double> TimeGen(float lambdaParm, int numEvents)
    {
        List<int> numEvent = new List<int>();
        List<double> interEventTimes = new List<double>();
        List<double> eventTimes = new List<double>();
        double eventTime = 0;
        double n;
        double interEvent;
        for (int i = 0; i < numEvents; i++)
        {
            numEvent.Add(i);
            System.Random random = new System.Random();
            n = random.NextDouble();
            interEvent = -Math.Log(1.0 - n) / lambdaParm;
            interEventTimes.Add(interEvent);

            eventTime = eventTime + interEvent;
            eventTimes.Add(eventTime);
        }
        return interEventTimes;
    }


    void Start()
    {
        StartCoroutine(WaitSpawner());

    }

    void Update()
    {
    }

    IEnumerator WaitSpawner()
    {
        List<double> myPoisson = TimeGen(lambdaVal, eventVal);
        List<float> myPoissonFloat = myPoisson.ConvertAll(Convert.ToSingle);

        while (passengerCount < myPoisson.Count)
        {
            yield return new WaitForSeconds(myPoissonFloat[i]);
            i++;
            xPos = UnityEngine.Random.Range(-45, -40);
            zPos = UnityEngine.Random.Range(-40, -35);

            GameObject clone = Instantiate(myPassenger, new Vector3(xPos, 0.03f, zPos), Quaternion.identity);
            clone.GetComponent<NavMeshAgent>();
            //scale = UnityEngine.Random.Range(0.5f, 0.7f);
            //clone.transform.localScale = new Vector3(scale, 2, scale);
            //clone.GetComponent<NavMeshAgent>().speed = UnityEngine.Random.Range(0.1f, 10.0f);

            passengerCount += 1;
        }
        yield return new WaitForSeconds(70.0f);
        Application.Quit();
    }

}
