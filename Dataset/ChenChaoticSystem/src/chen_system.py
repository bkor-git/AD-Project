
# -*- coding: utf-8 -*-
"""
Created on Thu Aug 21 08:30:43 2025

@author: Bahar

Chen Chaotic System with Environmental Coupling

References:
1. Chen, G., & Ueta, T. (1999). Yet Another Chaotic Attractor. 
   International Journal of Bifurcation and Chaos, 9, 1465–1466.
2. Quintero-Quiroz, C., & Cosenza, M. G. (2015). 
   Collective behavior of chaotic oscillators with environmental coupling. 
   Chaos, Solitons & Fractals, 71, 41–45. https://doi.org/10.1016/j.chaos.2014.12.001

"""

import numpy as np

def chen_env(t, y, N, a, b, c, lambda_env, epsilon1, epsilon2):
    """
    Chen system dynamics with environmental coupling.

    Parameters
    ----------
    t : float
        Current time (required by solvers, not used in autonomous system).
    y : ndarray, shape (3*N + 1,)
        State vector for N oscillators plus environment.
        Ordered as [x1, y1, z1, x2, y2, z2, ..., w].
    N : int
        Number of oscillators.
    a, b, c : float
        Chen system parameters.
    lambda_env : float
        Decay rate of the environment.
    epsilon1, epsilon2 : float
        Coupling strengths.

    Returns
    -------
    dydt : ndarray, shape (3*N + 1,)
        Time derivatives of the state vector.
    """
    w = y[-1]
    x = y[0:3*N:3]
    y_vec = y[1:3*N:3]
    z = y[2:3*N:3]

    dw = -lambda_env * w + (epsilon1 / N) * np.sum(x)
    dx = a * (y_vec - x) + epsilon2 * w
    dy = (c - a) * x - x * z + c * y_vec
    dz = x * y_vec - b * z

    dydt = np.zeros(3*N + 1)
    dydt[0:3*N:3] = dx
    dydt[1:3*N:3] = dy
    dydt[2:3*N:3] = dz
    dydt[-1] = dw
    return dydt
