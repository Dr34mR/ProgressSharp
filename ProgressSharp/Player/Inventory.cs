using System;
using System.Collections.Generic;
using System.Linq;
using ProgressSharp.GameClasses;
using ProgressSharp.Helpers;

namespace ProgressSharp.Player
{
    public class Inventory
    {
        public delegate void InventoryEventHandler(object sender, InventoryArgs args);

        public event EventHandler GoldChanged;

        public event InventoryEventHandler ItemRemoved;
        public event InventoryEventHandler ItemChanged;
        public event InventoryEventHandler ItemAdded;

        public readonly List<InventoryItem> Items = new List<InventoryItem>();

        public int Gold { get; set; }

        public ProgressBar EncumBar = new ProgressBar();

        public void AddGold(int quantity)
        {
            Gold += quantity;

            var prefix = quantity < 0 ? "Spent" : "Got paid";
            var indefinite = StringHelpers.Indefinite("gold piece", quantity);
            Logger.Info($"{prefix} {indefinite}");

            GoldChanged?.Invoke(this, new EventArgs());
        }

        public void Pop(int index)
        {
            var item = Items[index];
            Items.Remove(item);

            var indefinite = StringHelpers.Indefinite(item.Name, item.Quantity);
            Logger.Info($"Lost {indefinite}");

            SyncEncumberance();
            ItemRemoved?.Invoke(this, new InventoryArgs(item));
        }

        public void Add(string itemName, int quantity)
        {
            var indefinite = StringHelpers.Indefinite(itemName, quantity);
            Logger.Info($"Gained {indefinite}");

            var match = Items.FirstOrDefault(i => i.Name.Equals(itemName));

            if (match != null)
            {
                match.Quantity += 1;
                ItemChanged?.Invoke(this, new InventoryArgs(match));
            }
            else
            {
                var newItem = new InventoryItem {Name = itemName, Quantity = quantity};
                Items.Add(newItem);
                ItemAdded?.Invoke(this, new InventoryArgs(newItem));
            }

            SyncEncumberance();
        }

        private void SyncEncumberance()
        {
            EncumBar.Reposition(Items.Select(i => i.Quantity).Sum());
        }

        public void SetCapacity(int capacity)
        {
            EncumBar.Reset(capacity, EncumBar.Position);
        }
    }
}
