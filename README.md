![Status](https://img.shields.io/badge/status-updating-yellow) 
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE.txt)
# 🚧 Work in Progress 🚧
This repository is still being updated. Features and code may change.  

>  **Note:** Finalized features and code will be available by the end of October, following the publication of our accepted conference paper at the 33rd European Signal Processing Conference (EUSIPCO 2025). Stay tuned for updates!

# Overview
This repository supplements our paper "Towards Real-Time Detection of Anomalous Behavior in Crowds from Accelerometer Time Series," accepted in EUSIPCO 2025. It provides synthetic datasets for anomaly detection (AD) and change point detection (CPD) in **multi-entity, multivariate time series data**, enabling reproducibility and further research on crowd anomaly detection.

## Link to publications
If you use this project for research, please cite the relevant publications:

- **Crowd Simulation (Train Station) Dataset:**
Anomaly Detection: B. Kor, B. Gaikwad, A. Patra, E. Miller, "Towards Real-Time Detection of Anomalous Behavior in Crowds from Accelerometer Time Series". In: Proceedings EUSIPCO 2025. https://doi.org/... (pdf here)

- **Crowd Simulation (Bi-directional Corridor) and ChenChaotic System Datasets:**  
The citation for this work will be provided after the submission of the relevant paper.

## Citation
### BibTeX
```
@INPROCEEDINGS{bkor_AD_MEMTS,
  author={Kor, Bahar and Gaikwad, Bipin and Patra, Abani and Miller, Eric},
  booktitle={2025 33nd European Signal Processing Conference (EUSIPCO)}, 
  title={Towards Real-Time Detection of Anomalous Behavior in Crowds from Accelerometer Time Series}, 
  year={2025},
  volume={},
  number={},
  pages={1742-1746},
  doi=...,
  note= {to appear, October 2025}}
```

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
This material is based upon work supported by the U.S. Department of Homeland Security under Grant Awards 22STESE00001-01-00, 22STESE00001-02-00, and 22STESE00001-03-02. The views and conclusions contained in this document are those of the authors and should not be interpreted as necessarily representing the official policies, either expressed or implied, of the U.S. Department of Homeland Security. ELM acknowledges support from the National Science Foundation's ID/R Program.

## Contact
For any further information or assistance, please don’t hesitate to reach out to us at [bahar.kor@tufts.edu].

Thank you for being a part of this project! 🚀
