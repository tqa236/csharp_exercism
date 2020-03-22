using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber, (double)r.numerator / r.denominator);
    }
}

public struct RationalNumber
{
    // int numerator;
    public int numerator { get; set; }
    public int denominator { get; set; }
    public RationalNumber(int numerator, int denominator)
    {
        int gcd = GCD(numerator, denominator);
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;
    }



    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r2.denominator + r1.denominator * r2.numerator, r1.denominator * r2.denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r2.denominator - r1.denominator * r2.numerator, r1.denominator * r2.denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r2.numerator, r1.denominator * r2.denominator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r2.denominator, r1.denominator * r2.numerator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(numerator), Math.Abs(denominator));
    }

    public RationalNumber Reduce()
    {
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Exprational(int power)
    {
        return new RationalNumber(Convert.ToInt32(Math.Pow(numerator, power)), Convert.ToInt32(Math.Pow(denominator, power)));
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow(baseNumber, (double)numerator / denominator);
    }

    public static int GCD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }

        return GCD(b, a % b);

    }
}