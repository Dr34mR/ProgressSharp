using System.Collections.Generic;
using ProgressSharp.Enums;

namespace ProgressSharp.Player
{
    public class Equipment
    {
        public delegate void EquipmentEventHandler(object sender, EquipmentArgs args);

        public event EquipmentEventHandler EquipmentChanged;

        private readonly Dictionary<EquipmentType, string> _loadout = new Dictionary<EquipmentType, string>
        {
            {EquipmentType.Weapon, "Sharp Rock"},
            {EquipmentType.Hauberk, "-3 Burlap"}
        };

        public string GetItem(EquipmentType type)
        {
            return _loadout.ContainsKey(type) ? _loadout[type] : string.Empty;
        }

        public void Put(EquipmentType type, string item)
        {
            if (_loadout.ContainsKey(type))
            {
                _loadout[type] = item;
            }
            else
            {
                _loadout.Add(type, item);
            }

            EquipmentChanged?.Invoke(this, new EquipmentArgs(type, item));
        }
    }
}
