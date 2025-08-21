# -*- coding: utf-8 -*-
"""
Created on Thu Aug 21 12:36:28 2025

@author: Bahar
"""

import os
import pandas as pd
import numpy as np
from generate_data import generate_chen_data


def save_dataset(output_path, num_folders, num_files_per_folder,
                 P, t_max, dt, t_switch,
                 a, b, c1, c2, lambda_env,
                 epsilon1_on, epsilon2_on,
                 epsilon1_off, epsilon2_off,
                 mode="normal"):
    """
    Generate Chen Coupled dataset and save them into folders and CSV files.
    
    Parameters
    ----------
    mode : str
        "normal" -> no change in c after t_switch
        "abnormal" -> c switches to c2 after t_switch
    """
    os.makedirs(output_path, exist_ok=True)

    for folder_idx in range(num_folders):
        # Pass the mode to the data generator
        t_full, sol_full = generate_chen_data(P, t_max, dt, t_switch,
                                              a, b, c1, c2, lambda_env,
                                              epsilon1_on, epsilon2_on,
                                              epsilon1_off, epsilon2_off,
                                              mode=mode)

        folder_path = os.path.join(output_path, f'folder_{folder_idx}')
        os.makedirs(folder_path, exist_ok=True)

        for file_idx in range(num_files_per_folder):
            data_to_save = np.vstack((
                t_full,
                sol_full[3*file_idx],
                sol_full[3*file_idx + 1],
                sol_full[3*file_idx + 2]
            )).T

            df = pd.DataFrame(data_to_save, columns=['time', 'x', 'y', 'z'])
            df.to_csv(os.path.join(folder_path, f'file_{file_idx}.csv'), index=False)

        print(f"Saved folder {folder_idx} with {num_files_per_folder} files ({mode} samples).")
