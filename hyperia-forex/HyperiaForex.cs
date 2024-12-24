using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void ValidateCurrencies(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException("Cannot compare different currencies");
        }
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return left.amount == right.amount;
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return left.amount != right.amount;
    }

    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return left.amount < right.amount;
    }

    public static bool operator >(CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return left.amount > right.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return new CurrencyAmount(left.amount + right.amount, left.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return new CurrencyAmount(left.amount - right.amount, left.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount amount, decimal factor)
    {
        return new CurrencyAmount(amount.amount * factor, amount.currency);
    }

    public static CurrencyAmount operator *(decimal factor, CurrencyAmount amount)
    {
        return amount * factor;
    }

    public static CurrencyAmount operator /(CurrencyAmount amount, decimal divisor)
    {
        return new CurrencyAmount(amount.amount / divisor, amount.currency);
    }

    public static explicit operator double(CurrencyAmount amount)
    {
        return (double)amount.amount;
    }

    public static implicit operator decimal(CurrencyAmount amount)
    {
        return amount.amount;
    }

    public override bool Equals(object obj)
    {
        if (obj is CurrencyAmount other)
        {
            ValidateCurrencies(this, other);
            return amount == other.amount;
        }
        return false;
    }

    public override int GetHashCode() => amount.GetHashCode() ^ currency.GetHashCode();
}