using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculation
{
    private static float multiplier = 1.15f;

    public static int ExponentialRise(int baseValue, int n)
    {
        return Mathf.CeilToInt(baseValue * Mathf.Pow(multiplier, n));
    }
}
