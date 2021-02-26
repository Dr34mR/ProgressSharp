using System.Collections.Generic;
using ProgressSharp.Enums;

namespace ProgressSharp.Character
{
    public static class Races
    {
        public static List<Race> GetRaces()
        {
            return new List<Race>
            {
                new Race("Half Orc", new Attributes {StatType.HpMax}),
                new Race("Half Man", new Attributes {StatType.Charisma}),
                new Race("Half Halfling", new Attributes {StatType.Dexterity}),
                new Race("Double Hobbit", new Attributes {StatType.Strength}),
                new Race("Hob-Hobbit", new Attributes {StatType.Dexterity, StatType.Condition}),
                new Race("Low Elf", new Attributes {StatType.Condition}),
                new Race("Dung Elf", new Attributes {StatType.Wisdom}),
                new Race("Talking Pony", new Attributes {StatType.MpMax,StatType.Intelligence}),
                new Race("Gyrognome", new Attributes {StatType.Dexterity}),
                new Race("Lesser Dwarf", new Attributes {StatType.Condition}),
                new Race("Crested Dwarf", new Attributes {StatType.Charisma}),
                new Race("Eel Man", new Attributes {StatType.Dexterity}),
                new Race("Panda Man", new Attributes {StatType.Condition, StatType.Strength}),
                new Race("Trans-Kobold", new Attributes {StatType.Wisdom}),
                new Race("Enchanted Motorcycle", new Attributes {StatType.MpMax}),
                new Race("Will o' the Wisp", new Attributes {StatType.Wisdom}),
                new Race("Battle-Finch", new Attributes {StatType.Dexterity, StatType.Intelligence}),
                new Race("Double Wookiee", new Attributes {StatType.Strength}),
                new Race("Skraeling", new Attributes {StatType.Wisdom}),
                new Race("Demicanadian", new Attributes {StatType.Condition}),
                new Race("Land Squid", new Attributes {StatType.Strength, StatType.HpMax}),
            };
        }
    }
}