using System.Collections.Generic;
using ProgressSharp.Enums;

namespace ProgressSharp.Character
{
    public class Klasses : List<Klass>
    {
        public static List<Klass> GetKlasses()
        {
            return new List<Klass>
            {
                new Klass("Ur-Paladin", new Attributes { StatType.Wisdom, StatType.Condition }),
                new Klass("Voodoo Princess", new Attributes { StatType.Intelligence, StatType.Charisma }),
                new Klass("Robot Monk", new Attributes { StatType.Strength }),
                new Klass("Mu-Fu Monk", new Attributes { StatType.Dexterity }),
                new Klass("Mage Illusioner", new Attributes { StatType.Intelligence, StatType.MpMax }),
                new Klass("Shiv-Knight", new Attributes { StatType.Dexterity }),
                new Klass("Inner Mason", new Attributes { StatType.Condition }),
                new Klass("Fighter/Organist", new Attributes { StatType.Charisma, StatType.Strength }),
                new Klass("Puma Burgular", new Attributes { StatType.Dexterity }),
                new Klass("Runeloremaster", new Attributes { StatType.Wisdom }),
                new Klass("Hunter Strangler", new Attributes { StatType.Dexterity, StatType.Intelligence }),
                new Klass("Battle-Felon", new Attributes { StatType.Strength }),
                new Klass("Tickle-Mimic", new Attributes { StatType.Wisdom, StatType.Intelligence }),
                new Klass("Slow Poisoner", new Attributes { StatType.Condition }),
                new Klass("Bastard Lunatic", new Attributes { StatType.Condition }),
                new Klass("Jungle Clown", new Attributes { StatType.Dexterity, StatType.Charisma }),
                new Klass("Birdrider", new Attributes { StatType.Wisdom }),
                new Klass("Vermineer", new Attributes { StatType.Intelligence })
            };
        }
    }
}