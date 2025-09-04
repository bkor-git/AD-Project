# 📊 Multivariate Time Series Anomaly Detection Models
This folder contains implementations and usage examples of Multivariate Time Series Anomaly Detection Models, based on the paper:  
>  Shreshth Tuli, Giuliano Casale, and Nicholas R. Jennings. 2022. TranAD: deep transformer networks for anomaly detection in multivariate time series data. Proc. VLDB Endow. 15, 6 (February 2022), 1201–1214. https://doi.org/10.14778/3514061.3514067

Original Source Code:  
https://github.com/imperial-qore/TranAD.git



## 📌 Usage:
The `codes` folder contains the **updated and adapted code** from the original repository, with some modifications.

You can refer to **`example_usage.ipynb`** to see how to set up the environment, load datasets, and run the models. This notebook provides step-by-step instructions to help you get started quickly.

### 📈 Note:
To run a model on a dataset, use the following command:
```bash
python3 main.py --model <model> --dataset <dataset> --retrain
```

Where `<model>` can be one of:
`TranAD`, `GDN`, `MAD_GAN`, `MTAD_GAT`, `MSCRED`, `USAD`, `OmniAnomaly`, `LSTM_AD`

And `<dataset>` can be one of:
`SMAP`, `MSL`, `SWaT`, `WADI`, `SMD`, `MSDS`, `MBA`, `UCR`, `NAB`

To train with 20% of the data, use:
```bash
python3 main.py --model <model> --dataset <dataset> --retrain --less
```

You can use the parameters in src/params.json to set values in src/constants.py for each file.

>  **Disclaimer:** The implementations in this repository are **from the original TranAD GitHub repository** for ease of use and integration. They may not produce identical results to those reported in the original paper. For exact baseline results and codes, please refer to the original repositories linked in the TranAD paper.


>  **Important:** If you use the datasets provided in the `data/` folder, please cite them properly according to their original sources.


