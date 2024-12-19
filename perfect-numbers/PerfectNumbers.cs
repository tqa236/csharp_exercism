using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be a positive integer.");
        }

        int aliquotSum = Enumerable.Range(1, number / 2)
                                   .Where(divisor => number % divisor == 0)
                                   .Sum();

        if (aliquotSum == number)
        {
            return Classification.Perfect;
        }
        else if (aliquotSum > number)
        {
            return Classification.Abundant;
        }
        else
        {
            return Classification.Deficient;
        }
    }
}
