using System.Collections.Generic;

namespace ProgressSharp.GameClasses
{
    public class OffensiveBuffs : List<EquipmentPreset>
    {
        public OffensiveBuffs()
        {
            var list = new List<string>
            {
                "Polished|+1",
                "Serrated|+1",
                "Heavy|+1",
                "Pronged|+2",
                "Steely|+2",
                "Vicious|+3",
                "Venomed|+4",
                "Stabbity|+4",
                "Dancing|+5",
                "Invisible|+6",
                "Vorpal|+7"
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