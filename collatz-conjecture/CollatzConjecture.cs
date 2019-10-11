using System;

public static class CollatzConjecture
{
    private const string Message = "Input must be a positive integer.";

    public static int Steps(int number)
    {
        if (number < 1){
            throw new System.ArgumentException(Message);
        }
        if (number == 1){
            return 0;
        }
        if (number % 2 == 0){
            return Steps(number/2) + 1;
        }
        return Steps(3 * number + 1) + 1;
    }
}