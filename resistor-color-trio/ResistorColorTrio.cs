using System;
using System.Collections.Generic;

public static class ResistorColorTrio
{
    private static readonly Dictionary<string, int> ColorMap = new()
    {
        { "black", 0 }, { "brown", 1 }, { "red", 2 }, { "orange", 3 }, { "yellow", 4 },
        { "green", 5 }, { "blue", 6 }, { "violet", 7 }, { "grey", 8 }, { "white", 9 }
    };

    public static string Label(string[] colors)
    {
        if (colors.Length < 3) throw new ArgumentException("At least three colors are required.");
        
        int value = ColorMap[colors[0]] * 10 + ColorMap[colors[1]];
        int multiplier = (int)Math.Pow(10, ColorMap[colors[2]]);
        int resistance = value * multiplier;
        
        return resistance >= 1_000 ? $"{resistance / 1_000} kiloohms" : $"{resistance} ohms";
    }
}