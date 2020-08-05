using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        string clean_input = Regex.Replace(input.ToLower(), "[^a-z]", "");
        var uniqueChars = new HashSet<Char>(clean_input.ToCharArray());
        return uniqueChars.Count == 26;
    }
}
