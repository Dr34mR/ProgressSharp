using System;
using ProgressSharp.Enums;

namespace ProgressSharp.Player
{
    public class EquipmentArgs : EventArgs
    {
        public EquipmentArgs(EquipmentType type, string item)
        {
            Type = type;
            Item = item;
        }

        public EquipmentType Type { get; }
        public string Item { get; }
    }
}