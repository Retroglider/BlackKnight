using System;
using System.Linq;

namespace DeveloperSample.Algorithms;

public static class Algorithms
{
    public static int GetFactorial(int n)
        {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * GetFactorial(n - 1);
        }
    }
        

public static string FormatSeparators(params string[] items)
    {
        string joined = string.Join(", ",  items.Take(items.Length - 1));
        joined += $" and {items.Last()}";
        return joined;
    }
}