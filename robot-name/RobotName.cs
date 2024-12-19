using System;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<string> usedNames = new HashSet<string>();
    private static Random random = new Random();
    private string name;

    public string Name
    {
        get
        {
            if (name == null)
            {
                GenerateUniqueName();
            }
            return name;
        }
    }

    public void Reset()
    {
        name = null;
        GenerateUniqueName();
    }

    private void GenerateUniqueName()
    {
        do
        {
            name = GenerateRandomName();
        } while (!usedNames.Add(name));
    }

    private string GenerateRandomName()
    {
        char letter1 = (char)('A' + random.Next(26));
        char letter2 = (char)('A' + random.Next(26));

        int number = random.Next(100, 1000);

        return $"{letter1}{letter2}{number}";
    }
}
