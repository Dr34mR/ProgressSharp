using System.Collections.Generic;
using System.Linq;
using ProgressSharp.Helpers;

namespace ProgressSharp.Extensions
{
    public static class ListExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list.ElementAt(RandomSingleton.Next(0, list.Count));
        }

        public static T Choice<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable.ToArray();

            return array[RandomHelper.Below(array.Length)];
        }

        public static T ChoiceLow<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable.ToArray();

            return array[RandomHelper.BelowLow(array.Length)];
        }
    }
}