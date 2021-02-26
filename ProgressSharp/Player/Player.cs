using System;
using System.Collections.Generic;
using System.Linq;
using ProgressSharp.Character;
using ProgressSharp.Enums;
using ProgressSharp.Extensions;
using ProgressSharp.GameClasses;
using ProgressSharp.Helpers;
using ProgressSharp.PlayerTasks;

namespace ProgressSharp.Player
{
    public class Player
    {
        public delegate void PlayerEventHandler(object sender, EventArgs args);

        public event PlayerEventHandler NewTask;
        public event PlayerEventHandler LeveledUp;

        // ---------------------------

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Race Race { get; set; }
        public Klass Klass { get; set; }
        public Stats Stats { get; set; } = new Stats();

        public float Elapsed;

        // ---------------------------

        public ProgressBar ExpBar = new ProgressBar
        {
            Max = Mechanic.LevelUpTime(1)
        };
        public ProgressBar TaskBar = new ProgressBar();

        // ---------------------------

        public int Level { get; set; } = 1;

        // ---------------------------

        public QuestBook QuestBook = new QuestBook();
        public Inventory Inventory = new Inventory();
        public Equipment Equipment = new Equipment();
        public SpellBook SpellBook = new SpellBook();

        // ---------------------------

        public PlayerTask CurrentTask;
        public readonly List<PlayerTask> QueuedTasks = new List<PlayerTask>();

        public static Player CreatePlayer(string name, Race race, Klass klass, Stats stats)
        {
            return new Player
            {
                Birthday = DateTime.Now,
                Name = name,
                Race = race,
                Klass = klass,
                Stats = stats
            };
        }

        public void SetCapacity()
        {
            Inventory.EncumBar.Max = 10 + Stats[StatType.Strength];
        }

        public void SetTask(PlayerTask task)
        {
            Elapsed = 0;
            CurrentTask = task;
            TaskBar.Reset(task.Duration);
            Logger.Info($"{task.Description}...");
            NewTask?.Invoke(this, new EventArgs());
        }

        public int EquipPrice()
        {
            return 5 * (Level ^ 2) + 10 * Level + 20;
        }

        public void LevelUp()
        {
            Level += 1;

            Logger.Info($"Leveled up to level {Level}!");

            Stats.Increment(StatType.HpMax, Stats[StatType.Condition] / 3 + 1 + RandomHelper.Below(4));
            Stats.Increment(StatType.MpMax, Stats[StatType.Intelligence] / 3 + 1 + RandomHelper.Below(4));

            WinStat();
            WinStat();

            WinSpell();

            ExpBar.Reset(Mechanic.LevelUpTime(Level));
            
            LeveledUp?.Invoke(this, new EventArgs());
        }

        public void WinStat()
        {
            StatType? chosenStat = null;

            if (RandomHelper.Odds(1, 2))
            {
                chosenStat = Stats.Random().Key;
            }
            else
            {
                var t = Stats.Select(i => i.Value ^ 2).Sum();
                t = RandomHelper.Below(t);

                foreach (var (key, value) in Stats)
                {
                    chosenStat = key;
                    t -= value ^ 2;
                    if (t < 0) break;
                }
            }

            if (chosenStat == null) throw new Exception();

            Stats.Increment(chosenStat.Value);

            if (chosenStat == StatType.Strength)
            {
                Inventory.SetCapacity(10 + Stats[StatType.Strength]);
            }
        }

        public void WinSpell()
        {
            var spells = GameLists.Spells;

            var index = RandomHelper.BelowLow(Math.Min(Stats[StatType.Wisdom] + Level, spells.Count));
            var spell = spells[index];

            SpellBook.Add(spell, 1);
        }

        public void WinEquipment()
        {
            var allTypes = Enum.GetValues(typeof(EquipmentType)).Cast<EquipmentType>();
            var choice = allTypes.Random();

            List<EquipmentPreset> stuff;
            List<EquipmentPreset> better;
            List<EquipmentPreset> worse;

            // Figure out the modifier

            if (choice == EquipmentType.Weapon)
            {
                stuff = new Weapons();
                better = new OffensiveBuffs();
                worse = new OffensiveDebuffs();
            }
            else
            {
                if (choice == EquipmentType.Shield)
                {
                    stuff = new Shields();
                }
                else
                {
                    stuff = new Armors();
                }

                better = new DefensiveBuffs();
                worse = new DefensiveDebuffs();
            }

            // Fetch the equipment

            var equipment = Mechanic.PickEquipment(stuff, Level);
            
            var equipName = equipment.Name;
            
            var plus = Level - equipment.Quality;
            var modifierPool = plus < 0 ? worse : better;

            var count = 0;
            while (count < 2 && count < plus)
            {
                var modifier = modifierPool.Random();
                if (equipName.Contains(modifier.Name))
                {
                    break; // no repeats
                }

                if (Math.Abs(plus) < Math.Abs(modifier.Quality))
                {
                    break; // too much
                }
                
                equipName = $"{modifier.Name} {equipName}";
                plus -= modifier.Quality;
                count += 1;
            }

            equipName = plus < 0 
                ? $"{plus} {equipName}" 
                : $"+{plus} {equipName}";

            Logger.Info($"Gained {plus} {equipName}");

            Equipment.Put(choice, equipName);
        }

        public void WinItem()
        {
            Inventory.Add(Mechanic.SpecialItem(), 1);
        }
    }
}
