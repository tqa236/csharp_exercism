using System;
using System.Text.RegularExpressions;

public class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var cleanedPhrase = Regex.Replace(phrase, @"[^a-zA-Z\s-]", "");
        var words = cleanedPhrase.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
        return string.Join("", Array.ConvertAll(words, word => word[0].ToString().ToUpper()));
    }
}
