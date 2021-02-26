using System.Collections.Generic;
using ProgressSharp.Enums;

namespace ProgressSharp.Player
{
    public class Stats : Dictionary<StatType, int>
    {
        public delegate void StatsEventHandler(object sender, StatsArgs e);

        public event StatsEventHandler StatsChanged;
        
        public Stats()
        {

        }

        public void Increment(StatType type, int qty = 1)
        {
            this[type] += qty;

            var message = $"Increased {type:G} to {this[type]}";

            Logger.Info(message);
            StatsChanged?.Invoke(this, new StatsArgs());
        }
    }
}
