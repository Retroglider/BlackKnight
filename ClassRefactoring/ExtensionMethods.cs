using System;

namespace DeveloperSample.ClassRefactoring;

public static class EnumExtensionMethods
{
    public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
    {
        var enumName = typeof(TEnum).GetType().Name;
        if (string.IsNullOrEmpty(value))
        {
            throw new Exception($"No enumeration provided for {enumName}.");
        }

        return Enum.TryParse<TEnum>(value, true, out TEnum result) ?
            result :
            throw new Exception($"Unrecognized {enumName}: {value}.");
    }
}
