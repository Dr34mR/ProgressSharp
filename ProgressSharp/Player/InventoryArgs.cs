using System;

namespace ProgressSharp.Player
{
    public class InventoryArgs : EventArgs
    {
        public InventoryArgs(InventoryItem item)
        {
            Item = item;
        }

        public InventoryItem Item { get; }
    }
}