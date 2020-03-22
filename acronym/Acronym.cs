using System;
using System.Globalization;
using System.Linq;

public static class Acronym {
    public static string Abbreviate (string phrase) {
        TextInfo myTI = new CultureInfo ("en-US", false).TextInfo;
        phrase = phrase.Replace ("-", " ");
        phrase = myTI.ToTitleCase (phrase.ToLower ());
        return string.Join ("", phrase.Where (w => Char.IsLetter (w) && w == Char.ToUpper (w)));
    }
}