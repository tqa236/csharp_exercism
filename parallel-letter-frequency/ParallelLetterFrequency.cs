using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var letterCounts = new ConcurrentDictionary<char, int>();

        Parallel.ForEach(texts, text =>
        {
            foreach (var letter in text)
            {
                if (char.IsLetter(letter))
                {
                    char lowercaseLetter = char.ToLower(letter);
                    letterCounts.AddOrUpdate(lowercaseLetter, 1, (key, oldValue) => oldValue + 1);
                }
            }
        });

        return new Dictionary<char, int>(letterCounts);
    }
}
