using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string baseWord;
    private readonly string sortedBaseWord;
    
    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
        this.sortedBaseWord = SortString(baseWord);
    }

    public string[] FindAnagrams(string[] potentialMatches) => potentialMatches
            .Where(word => !word.Equals(baseWord, StringComparison.OrdinalIgnoreCase))
            .Where(word => SortString(word) == sortedBaseWord)
            .ToArray();

    private static string SortString(string word) => new string(word.ToLower().OrderBy(c => c).ToArray());
}
