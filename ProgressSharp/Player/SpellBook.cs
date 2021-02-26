using System.Collections.Generic;
using System.Linq;

namespace ProgressSharp.Player
{
    public class SpellBook 
    {
        public delegate void SpellEventHandler(object sender, SpellArgs args);

        public event SpellEventHandler SpellAdded;

        public event SpellEventHandler SpellChanged;

        private readonly List<PlayerSpell> _spells = new List<PlayerSpell>();

        public void Add(string spellName, int level)
        {
            var match = _spells.FirstOrDefault(i => i.Name.Equals(spellName));
            
            if (match != null)
            {
                match.Level += level;
                Logger.Info($"Learned {spellName} at level {match.Level}");
                SpellChanged?.Invoke(this, new SpellArgs(match));
            }
            else
            {
                var newSpell = new PlayerSpell {Name = spellName, Level = level};
                _spells.Add(newSpell);
                Logger.Info($"Learned {spellName} at level {newSpell.Level}");
                SpellAdded?.Invoke(this, new SpellArgs(newSpell));
            }
        }

        public PlayerSpell Best()
        {
            PlayerSpell returnSpell = null;
            foreach (var spell in _spells)
            {
                if (returnSpell == null)
                {
                    returnSpell = spell;
                }
                else if (returnSpell.Level < spell.Level)
                {
                    returnSpell = spell;
                }
            }
            return returnSpell;
        }
    }
}
