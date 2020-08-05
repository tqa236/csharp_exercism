using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        if (!Regex.IsMatch(sequence, @"^[ACGT]*$"))
        {
            throw new ArgumentException("Invalid strand.");
        }
        return (sequence + "ACGT").GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count() - 1);

    }
}