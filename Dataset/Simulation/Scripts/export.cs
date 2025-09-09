using System;
using System.IO;
using System.Xml;
using UnityEngine;

public class Export : MonoBehaviour
{
    public GameObject calibration;
    private XmlWriter logWriter;
    private string logFilePath;
    private GameObject[] trackedPlayers;

    public float interval = 0.1f; // save positions each 0.1 second
    public float tSample = 0.0f;  // sampling starts after this time
    string folderName;
    string folderPath;
    readonly int i = int.Parse(System.Environment.GetEnvironmentVariable("i"));

    void Start()
    {
        Time.timeScale = 1.0f;
        folderName = "MyOutput" + i.ToString();
        folderPath = Path.Combine(Application.persistentDataPath, folderName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        XmlWriterSettings wrapperSettings = new XmlWriterSettings { Indent = true };
        string basename = DateTime.Now.ToOADate().ToString();
        string wrappername = "wrapper-" + basename + ".xml";
        string newWrapper = Path.Combine(folderPath, wrappername);
        logFilePath = "log-" + basename + ".xml";
        string newPath = Path.Combine(folderPath, logFilePath);
        trackedPlayers = GameObject.FindGameObjectsWithTag("Player");

        // wrapper file 
        string doctype = "<!DOCTYPE trackerdata \n [ \n <!ENTITY locations SYSTEM \"" + logFilePath + "\">\n ]>";

        using (XmlWriter writer = XmlWriter.Create(newWrapper, wrapperSettings))
        {
            writer.WriteStartDocument();
            writer.WriteRaw(doctype);
            writer.WriteStartElement("trackerdata");

            // meta
            writer.WriteStartElement("meta");
            writer.WriteElementString("starttime", DateTime.Now.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("tracking");
            writer.WriteEntityRef("locations");
            writer.WriteEndElement(); 

            writer.WriteEndElement(); 
            writer.WriteEndDocument();
        }

        // log file
        XmlWriterSettings logSettings = new XmlWriterSettings
        {
            Indent = true,
            ConformanceLevel = ConformanceLevel.Document,
            OmitXmlDeclaration = false
        };

        logWriter = XmlWriter.Create(newPath, logSettings);
        logWriter.WriteStartDocument();
        logWriter.WriteStartElement("locations"); 

        InvokeRepeating("CollectData", 0, interval);
    }

    void CollectData()
    {
        foreach (GameObject trackedPlayer in trackedPlayers)
        {
            logWriter.WriteStartElement("location");
            logWriter.WriteAttributeString("runningTime", Time.timeSinceLevelLoad.ToString());

            logWriter.WriteElementString("PX", trackedPlayer.transform.position.x.ToString());
            logWriter.WriteElementString("PY", trackedPlayer.transform.position.y.ToString());
            logWriter.WriteElementString("PZ", trackedPlayer.transform.position.z.ToString());

            logWriter.WriteElementString("RX", trackedPlayer.transform.rotation.x.ToString());
            logWriter.WriteElementString("RY", trackedPlayer.transform.rotation.y.ToString());
            logWriter.WriteElementString("RZ", trackedPlayer.transform.rotation.z.ToString());

            logWriter.WriteEndElement(); 
            logWriter.Flush();
        }
    }

    void OnApplicationQuit()
    {
        if (logWriter != null)
        {
            logWriter.WriteEndElement();  
            logWriter.WriteEndDocument();
            logWriter.Close();
        }
    }
}
