using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation), "Operation cannot be null.");
        }

        if (operation == "")
        {
            throw new ArgumentException("Operation cannot be an empty string.", nameof(operation));
        }

        switch (operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {operand1 + operand2}";
            
            case "*":
                return $"{operand1} * {operand2} = {operand1 * operand2}";
            
            case "/":
                if (operand2 == 0)
                {
                    return "Division by zero is not allowed.";
                }
                return $"{operand1} / {operand2} = {operand1 / operand2}";

            default:
                throw new ArgumentOutOfRangeException(nameof(operation), $"Invalid operation: {operation}");
        }
    }
}
