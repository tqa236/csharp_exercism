using System;
using System.Linq;

public static class ArmstrongNumbers 
{
    public static bool IsArmstrongNumber(int number)
    {
        string numStr = number.ToString();
        int numDigits = numStr.Length;
        
        long sum = numStr.Sum(c => (long)Math.Pow(int.Parse(c.ToString()), numDigits));
        
        return sum == number;
    }
}