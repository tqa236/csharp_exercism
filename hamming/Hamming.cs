using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("The length of two strands should be the same.");
        }
        int count = 0;
        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i]) count = count + 1;
        }
        return count;
    }
}