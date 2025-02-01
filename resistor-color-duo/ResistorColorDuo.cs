using System;
using System.Collections.Generic;

public static class ResistorColorDuo
{
    private static readonly Dictionary<string, int> ColorMap = new()
    {
        { "black", 0 }, { "brown", 1 }, { "red", 2 }, { "orange", 3 }, { "yellow", 4 },
        { "green", 5 }, { "blue", 6 }, { "violet", 7 }, { "grey", 8 }, { "white", 9 }
    };

    public static int Value(string[] colors)
    {
        if (colors.Length < 2) throw new ArgumentException("At least two colors are required.");
        
        return ColorMap[colors[0]] * 10 + ColorMap[colors[1]];
    }
}
