using System;

public static class ResistorColor
{
    private static string[] colors = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    public static int ColorCode(string color) => Array.FindIndex(Colors(), m => m == color);
    public static string[] Colors() => colors;
}