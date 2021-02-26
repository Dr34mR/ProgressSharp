using System;
using System.Collections.Generic;
using ProgressSharp.Character;
using ProgressSharp.Extensions;
using ProgressSharp.GameClasses;
using ProgressSharp.PlayerTasks;

namespace ProgressSharp.Helpers
{
    public static class Mechanic
    {
        public static int LevelUpTime(int level)
        {
            // Seconds
            return 20 * level * 60;
        }

        public static EquipmentPreset PickEquipment(List<EquipmentPreset> stuff, int goal)
        {
            var result = stuff.Random();

            for (var i = 0; i < 5; i++)
            {
                var alternate = stuff.Random();
                if (Math.Abs(goal - alternate.Quality) < Math.Abs(goal - result.Quality))
                {
                    result = alternate;
                }
            }

            return result;
        }

        public static string SpecialItem()
        {
            return $"{InterestingItem()} of {GameLists.ItemOfs.Random()}";
        }

        public static string InterestingItem()
        {
            return $"{GameLists.ItemAttributres.Random()} {GameLists.Specials.Random()}";
        }

        public static string BoringItem()
        {
            return GameLists.BoringItems.Random();
        }

        public static string ImpressiveGuy()
        {
            var firstPart = GameLists.ImpressiveTitles.Random();

            var lastPart = RandomHelper.Odds(1, 2) 
                ? $" of the {Races.GetRaces().Random().Name}" 
                : $" of {StringHelpers.GenerateName()}";

            return firstPart + lastPart;
        }

        public static Monster UnnamedMonster(int level, int iterations)
        {
            var monsterList = Monsters.GetMonsters();
            var result = monsterList.Random();

            for (var i = 0; i < iterations; i++)
            {
                var alternative = monsterList.Random();
                if (Math.Abs(level - alternative.Level) < Math.Abs(level - result.Level))
                {
                    result = alternative;
                }
            }

            return result;
        }

        public static string NamedMonster(int level)
        {
            var monster = UnnamedMonster(level, 4);
            return StringHelpers.GenerateName() + " the " + monster.Name;
        }

        public static KillTask MonsterTask(int playerLevel, Monster questMonster)
        {
            var level = playerLevel;
            for (var i = 0; i < level; i++)
            {
                if (RandomHelper.Odds(2, 5))
                {
                    level += RandomHelper.Below(2) * 2 - 1;
                }
            }

            if (level < 1) level = 1;

            var isDefinite = false;
            Monster monster = null;
            var result = string.Empty;
            var lev = 0;

            if (RandomHelper.Odds(1, 25))
            {
                // Use an NPC every once in a while
                var race = Races.GetRaces().Random();

                if (RandomHelper.Odds(1, 2))
                {
                    result = $"passing {race.Name} {Klasses.GetKlasses().Random().Name}";
                }
                else
                {
                    result = $"{GameLists.Titles.Random()} {StringHelpers.GenerateName()} the {race.Name}";
                    isDefinite = true;
                }

                lev = level;
            }
            else if (questMonster != null && RandomHelper.Odds(1, 4))
            {
                // Use the quest monster
                monster = questMonster;
                result = monster.Name;
                level = monster.Level;
            }
            else
            {
                // pick the monster out of so many random ones closest to the level we want
                monster = UnnamedMonster(level, 5);
                result = monster.Name;
                lev = monster.Level;
            }

            var qty = 1;
            if (level - lev > 10)
            {
                // level is too low. multiply
                qty = (level + RandomHelper.Below(Math.Max(lev, 1))) / Math.Max(lev, 1);
                if (qty < 1)
                {
                    qty = 1;
                }
                level /= qty;
            }

            if (level - lev <= -10)
            {
                result = $"imaginary {result}";
            }
            else if (level - lev < -5)
            {
                var i = 10 + level - lev;
                i = 5 - RandomHelper.Below(i + 1);
                result = StringHelpers.Sick(i, StringHelpers.Young(lev - level - 1, result));
            }
            else if (level - lev < 0 && RandomHelper.Below(2) == 1)
            {
                result = StringHelpers.Sick(level - lev, result);
            }
            else if (level - lev < 0)
            {
                result = StringHelpers.Young(level - lev, result);
            }
            else if (level - lev >= 10)
            {
                result = $"messianic {result}";
            }
            else if (level - lev > 5)
            {
                var i = 10 - (level - lev);
                i = 5 - RandomHelper.Below(i + 1);
                result = StringHelpers.Big(i, StringHelpers.Special(level - lev - i, result));
            }
            else if (level - lev > 0 && RandomHelper.Below(2) == 1)
            {
                result = StringHelpers.Big(level - lev, result);
            }
            else if (level - lev > 0)
            {
                result = StringHelpers.Special(level - lev, result);
            }

            lev = level;
            level = lev * qty;
            if (!isDefinite)
            {
                result = StringHelpers.Indefinite(result, qty);
            }

            var duration = (2 * 3 * level * 1000) / playerLevel;

            return new KillTask($"Executing {result}", duration)
            {
                Monster = monster
            };
        }
    }
}
