using System;
class Validation
{
    public static bool IsValidString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException();
        }
        else
        {
            return true;
        }
    }
    public static bool IsValidDecimal(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Value cannot be negative");
        }
        else
        {
            return true;
        }
    }
}
