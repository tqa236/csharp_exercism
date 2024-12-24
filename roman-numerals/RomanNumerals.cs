using System.Collections.Generic;
using System.Text;

public static class RomanNumeralExtension
{
    private static readonly Dictionary<int, string> RomanMap = new Dictionary<int, string>
    {
        {1000, "M"},
        {900, "CM"},
        {500, "D"},
        {400, "CD"},
        {100, "C"},
        {90, "XC"},
        {50, "L"},
        {40, "XL"},
        {10, "X"},
        {9, "IX"},
        {5, "V"},
        {4, "IV"},
        {1, "I"}
    };

    public static string ToRoman(this int value)
    {
        var result = new StringBuilder();
        var remaining = value;

        foreach (var pair in RomanMap)
        {
            while (remaining >= pair.Key)
            {
                result.Append(pair.Value);
                remaining -= pair.Key;
            }
        }

        return result.ToString();
    }
}