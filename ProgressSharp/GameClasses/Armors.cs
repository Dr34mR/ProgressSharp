using System.Collections.Generic;

namespace ProgressSharp.GameClasses
{
    public class Armors : List<EquipmentPreset>
    {
        private static readonly List<string> ArmorList = new List<string>
        {
            "Lace|1",
            "Macrame|2",
            "Burlap|3",
            "Canvas|4",
            "Flannel|5",
            "Chamois|6",
            "Pleathers|7",
            "Leathers|8",
            "Bearskin|9",
            "Ringmail|10",
            "Scale Mail|12",
            "Chainmail|14",
            "Splint Mail|15",
            "Platemail|16",
            "ABS|17",
            "Kevlar|18",
            "Titanium|19",
            "Mithril Mail|20",
            "Diamond Mail|25",
            "Plasma|30"
        };

        public Armors()
        {
            foreach (var item in ArmorList)
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