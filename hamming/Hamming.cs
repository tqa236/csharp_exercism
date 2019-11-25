using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("The length of two strands should be the same.");
        }
        return firstStrand.Zip(secondStrand, (c1, c2) => (c1 == c2) ? 0 : 1).Sum();
    }
}