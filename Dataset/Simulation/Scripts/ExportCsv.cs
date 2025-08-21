
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ExportCsv : MonoBehaviour
{

    private string logFilePath;
    private List<string> csvLines = new List<string>();
    private GameObject[] trackedPlayers;

    public float interval = 0.02f; // Save positions every 0.02 seconds
    public float tSample = 0.0f;  // Sampling starts after this time
    string folderName;
    string folderPath;
    readonly int i = int.Parse(System.Environment.GetEnvironmentVariable("i"));
    private GameObject ePoint;
    private int playersReachedEndGoal = 0; // Track the number of players that have reached the end goal


    void Start()
    {
        Time.timeScale = 1.0f;
        ePoint = GameObject.FindGameObjectWithTag("EPoint");
        folderName = "MyOutput" + i.ToString();
        folderPath = Path.Combine(Application.persistentDataPath, folderName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string basename = DateTime.Now.ToOADate().ToString();
        logFilePath = "log-" + basename + ".csv";
        string newPath = Path.Combine(folderPath, logFilePath);
        trackedPlayers = GameObject.FindGameObjectsWithTag("Leg");

        InvokeRepeating("CollectData", 0.0f, 0.02f);
    }

    void CollectData()
    {
        foreach (GameObject trackedPlayer in trackedPlayers)
        {
            // Check if the player has reached the end goal
            if (HasPlayerReachedEndGoal(trackedPlayer))
            {
                playersReachedEndGoal++;
            }

            // Create a CSV line with the required data
            string csvLine = $"{Time.timeSinceLevelLoadAsDouble}, " +
                             $"{trackedPlayer.transform.position.x}, " +
                             $"{trackedPlayer.transform.position.y}, " +
                             $"{trackedPlayer.transform.position.z}, " +
                             $"{trackedPlayer.transform.eulerAngles.x}, " +
                             $"{trackedPlayer.transform.eulerAngles.y}, " +
                             $"{trackedPlayer.transform.eulerAngles.z}, " +
                             $"{trackedPlayer.transform.rotation.x}, " +
                             $"{trackedPlayer.transform.rotation.y}, " +
                             $"{trackedPlayer.transform.rotation.z}";

            csvLines.Add(csvLine);
        }

        if (playersReachedEndGoal == trackedPlayers.Length)
        {
            EndGame();
        }
    }

    bool HasPlayerReachedEndGoal(GameObject player)
    {
        // Implement your logic to check if a player has reached the end goal
        // For example, you can check the player's position and the position of the end goal.

        // Replace this with your actual logic
        float distanceToGoal = Vector3.Distance(player.transform.position, ePoint.transform.position);
        return distanceToGoal < 5.0f; // Change yourThresholdDistance as needed
    }

    void EndGame()
    {
        SaveDataToCSV();
    }

    void SaveDataToCSV()
    {
        string newPath = Path.Combine(folderPath, logFilePath);

        using (StreamWriter writer = new StreamWriter(newPath))
        {
            // Write the CSV header if needed
            writer.WriteLine("Time,PX,PY,PZ,REX,REY,REZ,RTX,RTY,RTZ");

            foreach (string csvLine in csvLines)
            {
                writer.WriteLine(csvLine);
            }
        }
    }
}