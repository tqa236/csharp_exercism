using System;
using System.Linq;
public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if ((sliceLength > numbers.Length) || (sliceLength <= 0))
        {
            throw new System.ArgumentException("Invalid slice's length.");
        }
        return Enumerable.Range(0, numbers.Length - sliceLength + 1)
        .Select(i => numbers.Substring(i, sliceLength)).ToArray();
    }
}