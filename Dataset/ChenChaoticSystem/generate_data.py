# -*- coding: utf-8 -*-
"""
Created on Thu Aug 21 12:21:05 2025

@author: Bahar
"""

import numpy as np
from scipy.integrate import solve_ivp
from chen_system import chen_env

def generate_chen_data(P, t_max, dt, t_switch,
                       a, b, c1, c2, lambda_env,
                       epsilon1_on, epsilon2_on,
                       epsilon1_off, epsilon2_off,
                       mode="normal"):
    """
    Simulate P coupled Chen oscillators with environmental coupling.
    For 'normal', simulate once with constant parameters.
    For 'abnormal', switch parameters at t_switch.
    """

    if mode == "normal":
        # Only one phase
        t_full = np.arange(0, t_max, dt)
        dim = 3*P + 1

        # Random initial conditions
        x0 = np.abs(np.random.uniform(-1, 1, P))
        y0 = np.abs(np.random.uniform(-1, 1, P))
        z0 = np.abs(np.random.uniform(-1, 1, P))
        w0 = 0.0

        y_init = np.zeros(dim)
        y_init[0:3*P:3] = x0
        y_init[1:3*P:3] = y0
        y_init[2:3*P:3] = z0
        y_init[-1] = w0

        sol = solve_ivp(
            chen_env,
            [t_full[0], t_full[-1]],
            y_init,
            t_eval=t_full,
            args=(P, a, b, c1, lambda_env, epsilon1_on, epsilon2_on)
        )

        sol_full = sol.y

    else:  # abnormal case with parameter switch
        t1 = np.arange(0, t_switch, dt)
        t2 = np.arange(t_switch, t_max, dt)
        t_full = np.concatenate((t1, t2))
        dim = 3*P + 1

        # Random initial conditions
        x0 = np.abs(np.random.uniform(-1, 1, P))
        y0 = np.abs(np.random.uniform(-1, 1, P))
        z0 = np.abs(np.random.uniform(-1, 1, P))
        w0 = 0.0

        y_init = np.zeros(dim)
        y_init[0:3*P:3] = x0
        y_init[1:3*P:3] = y0
        y_init[2:3*P:3] = z0
        y_init[-1] = w0

        sol1 = solve_ivp(
            chen_env,
            [t1[0], t1[-1]],
            y_init,
            t_eval=t1,
            args=(P, a, b, c1, lambda_env, epsilon1_on, epsilon2_on)
        )

        sol2 = solve_ivp(
            chen_env,
            [t2[0], t2[-1]],
            sol1.y[:, -1],
            t_eval=t2,
            args=(P, a, b, c2, lambda_env, epsilon1_off, epsilon2_off)
        )

        sol_full = np.hstack((sol1.y, sol2.y))

    return t_full, sol_full