using System.Collections.Generic;
using System.Linq;
using ProgressSharp.Enums;
using ProgressSharp.Extensions;
using ProgressSharp.Helpers;
using ProgressSharp.Player;

namespace ProgressSharp.GameClasses
{
    public class StatsBuilder
    {
        public List<Stats> History = new List<Stats>();

        public Stats Roll()
        {
            var stats = new Stats();

            var primeStats = EnumExtensions.PrimeStats();
            foreach (var statType in primeStats)
            {
                var value = 3 + 
                            RandomHelper.Below(6) +
                            RandomHelper.Below(6) +
                            RandomHelper.Below(6);

                stats.Add(statType, value);
            }

            var hpVal = RandomHelper.Below(8) + stats[StatType.Condition] / 6;
            stats.Add(StatType.HpMax, hpVal);

            var mpVal = RandomHelper.Below(8) + stats[StatType.Intelligence] / 6;
            stats.Add(StatType.MpMax, mpVal);

            History.Add(stats);
            return stats;
        }

        public Stats UnRoll()
        {
            if (History.Count < 1) return null;
            History.RemoveAt(History.Count - 1);
            return History.LastOrDefault();
        }
    }
}
