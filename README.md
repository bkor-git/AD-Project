![Status](https://img.shields.io/badge/status-updating-yellow)
# 🚧 Work in Progress 🚧
This repository is still being updated. Features and code may change.

# Overview
This repository supplements our paper "Towards Real-Time Detection of Anomalous Behavior in Crowds from Accelerometer Time Series," accepted in EUSIPCO 2025. It provides synthetic datasets for anomaly detection (AD) and change point detection (CPD) in **multi-entity, multivariate time series data**, enabling reproducibility and further research on crowd anomaly detection.

## Link to publications
If you use this project for research, please cite the relevant publications:

- **Crowd Simulation (Train Station) Dataset:**
Anomaly Detection: B. Kor, B. Gaikwad, A. Patra, E. Miller, "Towards Real-Time Detection of Anomalous Behavior in Crowds from Accelerometer Time Series". In: Proceedings EUSIPCO 2025. https://doi.org/... (pdf here)

- **Crowd Simulation (Bi-directional Corridor) and ChenChaotic System Datasets:**  
Change Point Detection: B. Kor, B. Gaikwad, A. Patra, E. Miller, "On Multi-entity, Multivariate Quickest Change Point Detection". https://doi.org/... (pdf here).

## Table Of Contents 
1. [Dataset](#dataset)
2. [Models](#model)
3. [Bug Reports](#Bug) 
4. [License](#license)
5. [Acknowledgements](#acknowledgements)
6. [Contact](#contact)

## Dataset
This folder contains the datasets used for evaluating the methods. You can either generate datasets using the provided codes and executable files, 
or  

- **Request Full Dataset Access**  
  The full dataset is too large to host on GitHub.
  To request access, email [bahar.kor@tufts.edu] with the subject: "Dataset-Name Full Dataset Access Request" 

  - **chenchaoticsystem** – Synthetic dataset generated using Coupled Chen Chaotic Systems.  
  - **simulation** – Synthetic datasets generated from Unity Environment. 

## Model
This folder contains the implementations of the different models:  
- **MTS-AD-Models** – Multivariate Time Series Anomaly Detection models. These are adapted implementations from the original GitHub repository: [TranAD-Repository](https://github.com/imperial-qore/TranAD.git)
  
- **SAE** – Simple AutoEncoder (SAE) implementation 

### Bug
If you find any bugs or issues, please send an email and provide detailed information about the problem.

## License
This project is licensed under the terms of the MIT license - see the LICENSE.txt file for details.

## Acknowledgements
We want to express our gratitude to the following:
* ...
* ...

## Contact
For any further information or assistance, please don’t hesitate to reach out to us at [bahar.kor@tufts.edu].

Thank you for being a part of this project! 🚀
