using System;
using System.Collections.Generic;
using System.Linq;

public static class Alphametics
{
    public static IDictionary<char, int> Solve(string equation)
    {
        // Parse the equation
        var parts = equation.Split(new[] { " == " }, StringSplitOptions.None);
        var leftSide = parts[0].Split(new[] { " + " }, StringSplitOptions.None);
        var rightSide = parts[1];

        // Extract unique letters and validate
        var uniqueLetters = new HashSet<char>(equation.Where(char.IsLetter));
        if (uniqueLetters.Count > 10)
        {
            throw new ArgumentException("Too many unique letters to assign digits.");
        }

        var letters = uniqueLetters.ToArray();
        var digits = Enumerable.Range(0, 10).ToArray();

        // Determine leading letters (cannot be zero)
        var leadingLetters = new HashSet<char>(
            leftSide.Select(word => word[0]).Concat(new[] { rightSide[0] })
        );

        // Sort letters by frequency of appearance
        Array.Sort(letters, (a, b) => equation.Count(c => c == b) - equation.Count(c => c == a));

        // Helper function to evaluate a word
        long Evaluate(string word, Dictionary<char, int> mapping)
        {
            return word.Aggregate(0L, (value, c) => value * 10 + mapping[c]);
        }

        // Backtracking function
        bool Backtrack(int index, Dictionary<char, int> mapping, HashSet<int> usedDigits)
        {
            if (index == letters.Length)
            {
                // All letters have been assigned; verify the equation
                var leftSum = leftSide.Sum(word => Evaluate(word, mapping));
                var rightValue = Evaluate(rightSide, mapping);
                return leftSum == rightValue;
            }

            var letter = letters[index];
            foreach (var digit in digits)
            {
                // Prune: Check if digit is used or if it violates leading zero constraint
                if (usedDigits.Contains(digit) || (digit == 0 && leadingLetters.Contains(letter)))
                {
                    continue;
                }

                // Assign digit to the letter
                mapping[letter] = digit;
                usedDigits.Add(digit);

                // Recurse to the next letter
                if (Backtrack(index + 1, mapping, usedDigits))
                {
                    return true;
                }

                // Backtrack: Undo the assignment
                usedDigits.Remove(digit);
                mapping.Remove(letter);
            }

            return false;
        }

        // Initialize the backtracking process
        var resultMapping = new Dictionary<char, int>();
        if (Backtrack(0, resultMapping, new HashSet<int>()))
        {
            return resultMapping;
        }

        throw new ArgumentException("No solution found.");
    }
}
