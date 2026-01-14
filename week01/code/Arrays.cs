using System;
using System.Collections.Generic;
using System.Linq;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        double[] results = new double[length];

        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1);
        }

        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if data is {1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3,
    /// the result should be {7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        if (data.Count == 0) return;

        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0) return;

        int splitIndex = data.Count - effectiveAmount;

        List<int> detachedPart = data.GetRange(splitIndex, effectiveAmount);

        data.RemoveRange(splitIndex, effectiveAmount);

        data.InsertRange(0, detachedPart);
    }
}