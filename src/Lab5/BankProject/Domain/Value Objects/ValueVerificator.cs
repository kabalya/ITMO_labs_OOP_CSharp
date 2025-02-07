namespace BankProject;

public static class ValueVerificator
{
    public static void NullStringVerificator(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("String Value Is Null");
        }
    }

    public static bool LengthVerificator(int? value)
    {
        if (value == 0)
        {
            return true;
        }

        return false;
    }
}