using System;

public static class StringExtension
{
    public static Int32 ToInt32(this string stringToParseInt)
    {
        int intParsed;

        Int32.TryParse(stringToParseInt, out intParsed);

        return intParsed;
    }
    public static bool ToBool(this string stringToParseBool)
    {
        bool boolParsed;

        bool.TryParse(stringToParseBool, out boolParsed);

        return boolParsed;
    }
}