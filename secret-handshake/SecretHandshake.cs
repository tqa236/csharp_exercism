using System;
using System.Collections.Generic;

public static class SecretHandshake
{
    private static readonly string[] Actions = { "wink", "double blink", "close your eyes", "jump" };

    public static string[] Commands(int commandValue)
    {
        var result = new List<string>();
        
        for (int i = 0; i < Actions.Length; i++)
        {
            if ((commandValue & (1 << i)) != 0)
            {
                result.Add(Actions[i]);
            }
        }
        
        if ((commandValue & 16) != 0)
        {
            result.Reverse();
        }
        
        return result.ToArray();
    }
}
