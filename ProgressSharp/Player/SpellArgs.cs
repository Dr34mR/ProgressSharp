using System;

namespace ProgressSharp.Player
{
    public class SpellArgs : EventArgs
    {
        public SpellArgs(PlayerSpell spell)
        {
            PlayerSpell = spell;
        }
        
        public PlayerSpell PlayerSpell { get; }
    }
}