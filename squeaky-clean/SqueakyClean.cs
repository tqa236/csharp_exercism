using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
            return string.Empty;

        var result = new StringBuilder();
        bool nextCharShouldBeUpperCase = false;

        foreach (char c in identifier)
        {
            if (char.IsControl(c))
            {
                result.Append("CTRL");
                continue;
            }

            if (char.IsWhiteSpace(c))
            {
                result.Append('_');
                continue;
            }

            if (c == '-')
            {
                nextCharShouldBeUpperCase = true;
                continue;
            }

            if (!char.IsLetter(c))
                continue;

            if (c >= 'α' && c <= 'ω')
                continue;

            char processedChar = nextCharShouldBeUpperCase 
                ? char.ToUpper(c) 
                : c;

            result.Append(processedChar);
            nextCharShouldBeUpperCase = false;
        }

        return result.ToString();
    }
}