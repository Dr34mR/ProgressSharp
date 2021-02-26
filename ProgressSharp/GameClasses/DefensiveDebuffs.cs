using System.Collections.Generic;

namespace ProgressSharp.GameClasses
{
    public class DefensiveDebuffs : List<EquipmentPreset>
    {
        public DefensiveDebuffs()
        {
            var list = new List<string>
            {
                "Holey|-1",
                "Patched|-1",
                "Threadbare|-2",
                "Faded|-1",
                "Rusty|-3",
                "Motheaten|-3",
                "Mildewed|-2",
                "Torn|-3",
                "Dented|-3",
                "Cursed|-5",
                "Plastic|-4",
                "Cracked|-4",
                "Warped|-3",
                "Corroded|-3"
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