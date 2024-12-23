using System;
using System.Text.RegularExpressions;
using System.Linq;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    public string[] SplitLogLine(string text)
    {
        if (string.IsNullOrEmpty(text))
            return new[] { string.Empty };
            
        return Regex.Split(text, @"<[\^*=\-]+>");
    }

    public int CountQuotedPasswords(string lines) => Regex.Matches(lines, @"""[^""]*password[^""]*""", RegexOptions.IgnoreCase).Count;

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d+", "");

    public string[] ListLinesWithPasswords(string[] lines) => lines.Select(line =>
        {
            var match = Regex.Match(line, @"\bpassword(\w+)\b", RegexOptions.IgnoreCase);
            if (match.Success && match.Groups[1].Value.Length > 0)
            {
                return $"{match.Value}: {line}";
            }
            return $"--------: {line}";
        }).ToArray();
}