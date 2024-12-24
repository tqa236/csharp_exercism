using System;

public static class CollatzConjecture
{
    private const string Message = "Input must be a positive integer.";

    public static int Steps(int number)
    {
        if (number < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(number), Message);
        }
        
        int steps = 0;
        long currentNumber = number; // Use long to prevent overflow
        
        while (currentNumber != 1)
        {
            currentNumber = (currentNumber % 2 == 0) 
                ? currentNumber / 2 
                : 3 * currentNumber + 1;
            steps++;
        }
        
        return steps;
    }
}