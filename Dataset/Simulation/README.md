
## Crowd Simulation with Unity
In this project, we utilize **Unity<sup>®</sup>** to simulate crowd behavior with multiple agents in various scenarios, including a train station waiting area and a bi-directional corridor. 

The simulation explores how complex patterns of movement can emerge from simple rules that mimic real-world crowd dynamics. By the end, we create a **crowded scene** with humanoid characters that:  
- Walk around the environment  
- Avoid collisions with each other  
- Move step by step toward their goals

This project demonstrates **agent-based modeling in Unity** for studying and visualizing realistic crowd behavior.

<table>
  <tr>
    <td align="center">
      <img src="gif/NormalSceneCloseUp.gif" width="320"><br>
      <b>Normal Scene Close-up</b>
    </td>
    <td align="center">
      <img src="gif/AbnormalSceneCloseUp.gif" width="320"><br>
      <b>Abnormal Scene Close-up</b>
    </td>
  </tr>
</table>


## Folder Structure
 * [BuildFiles](./)
 * [Scripts](./)
   * [DropCylinder.cs](./Scripts/DropCylinder.cs)
   * [ExportCsv.cs](./Scripts/ExportCsv.cs)
   * [Passenger.cs](./Scripts/Passenger.cs)
   * [PoissonArrival.cs](./Scripts/PoissonArrival.cs)
   * [Test.cs](./Scripts/Test.cs)
   * [Wander.cs](./Scripts/Wander.cs)
 * [CSVFiles](./)
   * [Normal]
   * [Abnormal]
 * [README.md](./)

### Dataset
The CSV files contain **time-series data** of agents’ coordinates, acceleration, rotation, and
identity number. 
- The data was exported from the Unity simulation for the **normal** and **abnormal** scenarios - Captured at regular intervals of 0.1 (10 Hz) seconds.
- Each **row** corresponds to a single measurement instance for an agent.
- Each **column** responds to a specific feature.

#### Features
* **t**: time  
*	**pX, pY, pZ**: Agen position coordinates
*	**aX, aY, aZ**: Agent acceleration along x, y, z axes 
*	**reX, reY, reZ**: Agent rotation (Euler angles)
*	**rtX, rtY, rtZ**: Agent rotation (transform)   
*	**ID**: Unique identifier for each agent

### Unity Environment
The exported data in this CSV file originates from the transform section of the Unity environment, which encompasses the essential attributes of position, rotation, and scale. The position coordinates represent the spatial location of each agent within the simulated environment, while rotation values indicate the orientation around the Y-axis. The scale attribute, not included in this dataset, denotes the dimensions of the agent. 

### Data Format
The CSV file is structured in a comma-separated value format, with each row representing a single measurement of an agent. The column is organized as follows: t, pX, pY, pZ, aX, aY, aZ, reX, reY, reZ, rtX, rtY, rtZ, ID. 

### Usage
You can use the exported CSV files for a variety of **time-series analysis tasks**, including:
- **Trajectory analysis**: Study the evolution of each agent’s position, acceleration, and rotation over time.  
- **Pattern and anomaly detection**: Identify unusual behaviors or movement anomalies among agents.  
- **Machine learning applications**: Train models to predict anomalies or forecast future agent positions based on historical data

### Scripts
This folder contains the Unity C# scripts that power the simulation for **train station waiting area**.
* **DropCylinder**:  
*	**ExportCsv**: 
*	**Passenger**:  
*	**PoissonArrival**: The code for controlling the arrival time of the agents in the scene.
*	**Wander**: Script to control the green agents that are wandering around in the scene. 
