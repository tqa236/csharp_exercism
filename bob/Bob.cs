using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();

        if (string.IsNullOrEmpty(statement))
        {
            return "Fine. Be that way!";
        }

        bool isQuestion = statement.EndsWith("?");
        bool isYelling = statement.Any(char.IsLetter) && statement.ToUpper() == statement;

        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }
        if (isYelling)
        {
            return "Whoa, chill out!";
        }
        if (isQuestion)
        {
            return "Sure.";
        }

        return "Whatever.";
    }
}