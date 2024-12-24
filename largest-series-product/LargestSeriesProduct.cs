using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        ValidateInput(digits, span);

        if (span == 0)
            return 1;

        long largestProduct = 0;
        for (int i = 0; i <= digits.Length - span; i++)
        {
            long product = CalculateProduct(digits.Substring(i, span));
            largestProduct = Math.Max(largestProduct, product);
        }

        return largestProduct;
    }

    private static void ValidateInput(string digits, int span)
    {
        if (span < 0)
            throw new ArgumentException("Span cannot be negative");
            
        if (span > digits.Length)
            throw new ArgumentException("Span cannot be greater than string length");
            
        if (span != 0 && digits.Length == 0)
            throw new ArgumentException("Span cannot be non-zero when string is empty");
            
        if (!digits.All(char.IsDigit))
            throw new ArgumentException("String must only contain digits");
    }

    private static long CalculateProduct(string digits) => digits.Select(c => (long)(c - '0')).Aggregate(1L, (a, b) => a * b);
}