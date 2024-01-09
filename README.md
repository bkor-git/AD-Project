# Overview
Welcome to AD-Project! This repository is home to a fantastic project that aims to generate to detect anomaly in the crowd. In this project, we work with a number of agents to simulate crowd behaviour in the different scenarios such as train station waiting area. We discover how patterns of movement can be formed from the simpliest of rules that mimic crowd behaviour in the real world. By the end, we have created a crowded scene with humanoid characters walking and avoiding each other as well as reaching to their goals step by step. 

## Table Of Contents 
1. [Dataset](#dataset)
   - [Unity Environment](#unity-environment)
   - [Data Format](#data-format)
   - [Usage](#usage)

2. [Simulation](#simulation)
   - [Scripts](#scripts)
   - [Build Files](#build-files)

3. [Code](#code)
   - [Bug Reports](#bug-reports)
   - [Feature Requests](#feature-requests)
   - [Pull Requests](#pull-requests)
4. [License](#license)
5. [Acknowledgements](#acknowledgements)
6. [Contact](#contact)

## Dataset
Within this folder, you will find a synthetic dataset closely mirroring accelerometer sensor data. The information is meticulously extracted from agents within manually crafted scenes, showcasing both normal and abnormal scenarios.
The CSV files contain time-series data of agents’ coordinates, acceleration, rotation, and identity. The data was exported from the Unity simulation for normal and abnormal scenario and captured at regular intervals of 0.02 (50 Hz) seconds. Each row represents a specific instance of measurement for an agent, and each column corresponds to a particular data attribute. The following attributes are included in the dataset:

* **t**: time  
*	**pX**: X-coordinate of the agent’s position  
*	**pY**: Y-coordinate of the agent’s position  
*	**pZ**: Z-coordinate of the agent’s position  
*	**aX**: Acceleration in the X-axis  
*	**aY**: Acceleration in the Y-axis  
*	**aZ**: Acceleration in the Z-axis  
*	**reX**: Rotation Euler in the X-axis  
*	**reY**: Rotation Euler in the Y-axis  
*	**reZ**: Rotation Euler in the Z-axis  
*	**rtX**: Rotation Transform in the X-axis  
*	**rtY**: Rotation Transform in the Y-axis  
*	**rtZ**: Rotation Transform in the Z-axis  
*	**ID**: Unique identifier for each agent

### Unity Environment
The exported data in this csv file originates from the transform section of the Unity environment, which encompasses the essential attributes of position, rotation, and scale. The position coordinates represent the spatial location of each agent withing the simulated environment, while rotation values indicate the orientation around Y-axis. The scale attribute, not included in this dataset, denotes the dimensions of the agent. 

### Data Format
The CSV file is structured in a comma-separated value format, with each row representing a single measurement of an agent. The column is organized as follows: t, pX, pY, pZ, aX, aY, aZ, reX, reY, reZ, rtX, rtY, rtZ, ID. 

### Usage
You can utilize these CSV files to perform various time-series analysis tasks, such as:
*	Analyzing the evolution of the agent’s position, acceleration, and rotation over time. 
*	Detecting patterns or anomalies in the movement behavior of agents.
*	Applying machine learning or statistical techniques to predict anomalies or future position based on historical data.


## Simulation
### Scripts
The Scripts section delves into the codes that powers the simulation. It includes explanations of the scripts responsible for simulating passenger behavior, managing events within the virtual train station waiting area.
* **DropCylinder**:  
*	**ExportCsv**: 
*	**Passenger**:  
*	**PoissonArrival**: The code for controlling the arrival time of the agents in the scene.
*	**Wander**: Script to control the green agents which are wandering around in the scene. 

### Build Files
The Build Files section provides practical information for users who want to experience the simulation firsthand. It includes instructions on how to run the executable files that bring your simulation to life, and export the information of the agents as csv files. 


## Code
Write explanation about the code here!!!
### Contributing 
We welcome contributions from the community to make AD-Project even more awesome!
Here's how you can contribute:
### Bug Reports 
If you find any bugs or issues, please send an email and provide detailed information about the problem.
### Feature Requests
Have a cool idea about the simulations? Let us know by sending an email and describing the enhancement or scene you have in your mind.
### Pull Requests 
If you'd like to contribute directly, fork the repository, create a new branch, and submit a pull request. Make sure to follow our contribution guidelines.

## License
This project is licensed under ...  - see the LICENSE.md file for details.

## Acknowledgements
We would like to express our gratitude to the following:
* ...
* ...

## Contact
For any further information or assistance, please don’t hesitate to reach out to us at [bahar.kor@tufts.edu].

Thank you for being a part of this project! 🚀
