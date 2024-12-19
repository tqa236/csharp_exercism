using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static (int, int, int)[] TripletsWithSum(int sum)
    {
        var triplets = new List<(int, int, int)>();
        int maxA = sum / 3;
        
        for (int a = 3; a < maxA; a++)
        {
            
            long numerator = (long)sum * sum - 2L * sum * a;
            int denominator = 2 * (sum - a);
            
            if (numerator <= 0 || denominator <= 0)
                continue;
                
            if (numerator % denominator == 0)
            {
                int b = (int)(numerator / denominator);

                if (b <= a)
                    continue;
                    
                int c = sum - a - b;
                
                if (b < c && a * a + b * b == c * c)
                {
                    triplets.Add((a, b, c));
                }
            }
        }
        
        return triplets.OrderBy(t => t.Item1)
                      .ThenBy(t => t.Item2)
                      .ToArray();
    }
}