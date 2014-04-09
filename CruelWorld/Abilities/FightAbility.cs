using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Abilities
{
    class FightAbility : IFigher
    {
        private readonly ICreature[] _owner;

        public FightAbility(params ICreature[] owner)
        {
            this._owner = owner;
        }

        public bool TryFight(params ICreature[] opponents)
        {
           var fight = new Fight(_owner, opponents);
           return fight.Resolve();
        }
    }
}
