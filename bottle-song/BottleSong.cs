public static class BottleSong
{
    public static string[] Recite(int startBottles, int takeDown)
    {
        var lyrics = new List<string>();

        for (int i = 0; i < takeDown; i++)
        {
            int currentBottles = startBottles - i;
            int nextBottles = currentBottles - 1;

            lyrics.Add($"{CapitalizeFirstLetter(NumToWords(currentBottles))} green {Pluralize("bottle", currentBottles)} hanging on the wall,");
            lyrics.Add($"{CapitalizeFirstLetter(NumToWords(currentBottles))} green {Pluralize("bottle", currentBottles)} hanging on the wall,");
            lyrics.Add("And if one green bottle should accidentally fall,");
            lyrics.Add($"There'll be {NumToWords(nextBottles)} green {Pluralize("bottle", nextBottles)} hanging on the wall.");

            if (i < takeDown - 1)
            {
                lyrics.Add(string.Empty); // Add an empty line between verses
            }
        }

        return lyrics.ToArray();
    }

    private static string NumToWords(int number)
    {
        return number switch
        {
            0 => "no",
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            6 => "six",
            7 => "seven",
            8 => "eight",
            9 => "nine",
            10 => "ten",
            _ => throw new ArgumentOutOfRangeException(nameof(number), "Number out of range")
        };
    }

    private static string Pluralize(string word, int count)
    {
        return count == 1 ? word : $"{word}s";
    }

    private static string CapitalizeFirstLetter(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return word;
        }
        return char.ToUpper(word[0]) + word.Substring(1);
    }
}
