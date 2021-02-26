using System.Collections.Generic;

namespace ProgressSharp.GameClasses
{
    public class DefensiveBuffs : List<EquipmentPreset>
    {
        public DefensiveBuffs()
        {
            var list =  new List<string>
            {
                "Studded|+1",
                "Banded|+2",
                "Gilded|+2",
                "Festooned|+3",
                "Holy|+4",
                "Cambric|+1",
                "Fine|+4",
                "Impressive|+5",
                "Custom|+3"
            };

            foreach (var item in list)
            {
                var itemSplit = item.Split("|");

                var name = itemSplit[0];
                var levelStr = itemSplit[1];
                var levelInt = int.Parse(levelStr.Replace("+", string.Empty));

                Add(new EquipmentPreset(name, levelInt));
            }
        }
    }
}