## Table Of Contents 
1. [Overview](#overview)
2. [Dataset](#dataset)
   - [Unity Environment](#unity-environment)
   - [Data Format](#data-format)
   - [Usage](#usage)
## Overview
Within this folder, you'll find a synthetic dataset closely mirroring accelerometer sensor data. The information is meticulously extracted from agents within manually crafted scenes, showcasing both normal and abnormal scenarios.

## Dataset
The CSV files contain time-series data of agents’ coordinates, acceleration, rotation, and
identity. The data was exported from the Unity simulation for normal and abnormal scenario and captured at 
regular intervals of 0.02 (50 Hz) seconds. Each row represents a specific 
instance of measurement for an agent, and each column corresponds to a particular data 
attribute. The following attributes are included in the dataset:

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
