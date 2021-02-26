using System.Collections.Generic;

namespace ProgressSharp.GameClasses
{
    public class OffensiveDebuffs : List<EquipmentPreset>
    {
        public OffensiveDebuffs()
        {
            var list = new List<string>
            {
                "Dull|-2",
                "Tarnished|-1",
                "Rusty|-3",
                "Padded|-5",
                "Bent|-4",
                "Mini|-4",
                "Rubber|-6",
                "Nerf|-7",
                "Unbalanced|-2"
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