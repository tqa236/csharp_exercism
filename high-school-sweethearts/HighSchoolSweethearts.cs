using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA} ♡ {studentB}".PadLeft(30 + studentA.Length).PadRight(61);

    public static string DisplayBanner(string studentA, string studentB) => @$"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA} +  {studentB}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";

    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours)
    {
        var germanCulture = new CultureInfo("de-DE");
        return $"{studentA} and {studentB} have been dating since {start.ToString("dd.MM.yyyy", germanCulture)} - that's {hours.ToString("N2", germanCulture)} hours";
    }
}