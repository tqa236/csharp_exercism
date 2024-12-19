using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException("Phone number cannot be null or empty.");
        }

        string digitsOnly = Regex.Replace(phoneNumber, "[^0-9]", "");

        if (digitsOnly.Length < 10 || digitsOnly.Length > 11)
        {
            throw new ArgumentException("Phone number must be 10 or 11 digits.");
        }

        if (digitsOnly.Length == 11)
        {
            if (digitsOnly[0] != '1')
            {
                throw new ArgumentException("11-digit phone numbers must start with '1'.");
            }
            digitsOnly = digitsOnly.Substring(1);
        }

        if (digitsOnly[0] == '0' || digitsOnly[0] == '1')
        {
            throw new ArgumentException("Area code cannot start with '0' or '1'.");
        }

        if (digitsOnly[3] == '0' || digitsOnly[3] == '1')
        {
            throw new ArgumentException("Exchange code cannot start with '0' or '1'.");
        }

        return digitsOnly;
    }
}
