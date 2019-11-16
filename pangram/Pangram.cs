using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        string clean_input = Regex.Replace(input.ToLower(), "[^a-z]", "");
        var uniqueChars = new HashSet<Char>(clean_input.ToCharArray());
        return uniqueChars.Count == 26;
    }
}
