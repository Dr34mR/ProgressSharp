using System.Collections.Generic;
using ProgressSharp.Enums;

namespace ProgressSharp.Extensions
{
    public static class EnumExtensions
    {
        public static List<StatType> PrimeStats()
        {
            return new List<StatType>
            {
                StatType.Strength,
                StatType.Condition,
                StatType.Dexterity,
                StatType.Intelligence,
                StatType.Wisdom,
                StatType.Charisma
            };
        }

        public static List<StatType> AllStats()
        {
            return new List<StatType>(PrimeStats())
            {
                StatType.HpMax,
                StatType.MpMax
            };
        }
    }
}
