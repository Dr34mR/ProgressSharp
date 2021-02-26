using System.Collections.Generic;

namespace ProgressSharp.GameClasses
{
    public class Shields : List<EquipmentPreset>
    {
        public Shields()
        {
            var list = new List<string>
            {
                "Parasol|0",
                "Pie Plate|1",
                "Garbage Can Lid|2",
                "Buckler|3",
                "Plexiglass|4",
                "Fender|4",
                "Round Shield|5",
                "Carapace|5",
                "Scutum|6",
                "Propugner|6",
                "Kite Shield|7",
                "Pavise|8",
                "Tower Shield|9",
                "Baroque Shield|11",
                "Aegis|12",
                "Magnetic Field|18"
            };

            foreach (var item in list)
            {
                var itemSplit = item.Split("|");

                var name = itemSplit[0];
                var levelStr = itemSplit[1];
                var levelInt = int.Parse(levelStr);

                Add(new EquipmentPreset(name, levelInt));
            }
        }
    }
}