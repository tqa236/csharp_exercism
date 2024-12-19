using System;
using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var cleanedWord = word.ToLower().Where(char.IsLetter);
        
        var seenCharacters = new HashSet<char>();

        foreach (var character in cleanedWord)
        {
            if (seenCharacters.Contains(character))
            {
                return false;
            }
            seenCharacters.Add(character);
        }

        return true;
    }
}
