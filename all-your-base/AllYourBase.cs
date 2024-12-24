using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1)
            throw new ArgumentException("Input base must be >= 2", nameof(inputBase));
        if (outputBase <= 1)
            throw new ArgumentException("Output base must be >= 2", nameof(outputBase));

        if (!inputDigits.Any() || inputDigits.All(d => d == 0))
            return new[] { 0 };

        if (inputDigits.Any(d => d < 0 || d >= inputBase))
            throw new ArgumentException("All digits must satisfy 0 <= d < input base", nameof(inputDigits));

        int decimalValue = 0;
        foreach (int digit in inputDigits)
        {
            decimalValue = decimalValue * inputBase + digit;
        }

        if (decimalValue == 0)
            return new[] { 0 };

        var outputDigits = new List<int>();
        while (decimalValue > 0)
        {
            outputDigits.Insert(0, decimalValue % outputBase);
            decimalValue /= outputBase;
        }

        return outputDigits.ToArray();
    }
}