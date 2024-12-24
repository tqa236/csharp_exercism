using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
}

public struct RationalNumber
{
    private readonly int numerator;
    private readonly int denominator;

    public int Numerator => numerator;
    public int Denominator => denominator;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero", nameof(denominator));
        }

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int gcd = Math.Abs(GCD(numerator, denominator));
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => new RationalNumber(
            r1.numerator * r2.denominator + r2.numerator * r1.denominator,
            r1.denominator * r2.denominator
        ).Reduce();

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => new RationalNumber(
            r1.numerator * r2.denominator - r2.numerator * r1.denominator,
            r1.denominator * r2.denominator
        ).Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => new RationalNumber(
            r1.numerator * r2.numerator,
            r1.denominator * r2.denominator
        ).Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        if (r2.numerator == 0)
        {
            throw new DivideByZeroException();
        }
        return new RationalNumber(
            r1.numerator * r2.denominator,
            r1.denominator * r2.numerator
        ).Reduce();
    }

    public RationalNumber Abs() => new RationalNumber(Math.Abs(numerator), denominator);

    public RationalNumber Reduce() => this;
    public RationalNumber Exprational(int power)
    {
        if (power == 0)
        {
            return new RationalNumber(1, 1);
        }

        if (power < 0)
        {
            // For negative powers, swap numerator and denominator and use absolute value of power
            return new RationalNumber(
                (int)Math.Pow(denominator, Math.Abs(power)),
                (int)Math.Pow(numerator, Math.Abs(power))
            );
        }

        return new RationalNumber(
            (int)Math.Pow(numerator, power),
            (int)Math.Pow(denominator, power)
        );
    }

    private static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        
        return a;
    }

    public override bool Equals(object obj)
    {
        if (obj is RationalNumber other)
        {
            return numerator == other.numerator && denominator == other.denominator;
        }
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(numerator, denominator);
}