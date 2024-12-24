using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        if (number < 2)
            return Array.Empty<long>();

        var factors = new List<long>();
        long divisor = 2;
        
        while (number > 1)
        {
            while (number % divisor == 0)
            {
                factors.Add(divisor);
                number /= divisor;
            }
            divisor += (divisor == 2) ? 1 : 2;

            if (divisor * divisor > number && number > 1)
            {
                factors.Add(number);
                break;
            }
        }

        return factors.ToArray();
    }
}