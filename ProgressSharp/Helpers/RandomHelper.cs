using System;
using ProgressSharp.Extensions;

namespace ProgressSharp.Helpers
{
    internal static class RandomHelper
    {
        internal static int Below(int num)
        {
            return RandomSingleton.Next(0, num - 1);
        }

        internal static int BelowLow(int num)
        {
            return Math.Min(Below(num), Below(num));
        }

        internal static bool Odds(int chance, int outOf)
        {                                   
            return Below(outOf) < chance;
        }
    }
}
