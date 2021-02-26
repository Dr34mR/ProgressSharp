using System;

namespace ProgressSharp.Extensions
{
    internal class RandomSingleton
    {
        private static readonly RandomSingleton Instance = new RandomSingleton();

        private readonly Random _r;

        public RandomSingleton()
        {
            _r = new Random();
        }

        public static int Next(int minValue, int maxValue)
        {
            return Instance._r.Next(minValue, maxValue);
        }
    }
}