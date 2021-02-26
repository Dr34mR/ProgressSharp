using System.ComponentModel;

namespace ProgressSharp.Enums
{
    public enum StatType
    {
        [Description("STR")]
        Strength = 0,

        [Description("CON")]
        Condition = 1,

        [Description("DEX")]
        Dexterity = 2,

        [Description("INT")]
        Intelligence = 3,

        [Description("WIS")]
        Wisdom = 4,

        [Description("CHA")]
        Charisma = 5,

        [Description("HP Max")]
        HpMax = 6,

        [Description("MP Max")]
        MpMax = 7
    }
}