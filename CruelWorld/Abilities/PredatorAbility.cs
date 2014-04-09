using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Abilities
{
    class PredatorAbility : IPredator
    {
        private readonly IEnumerable<ICreature> _owner;

        private readonly HashSet<Type> _victims;

        public PredatorAbility(IEnumerable<ICreature> owner, params Type[] victims)
        {
            this._owner = owner;
            _victims = new HashSet<Type>(victims);
        }

        public bool CanEat(ICreature creature)
        {
            return _victims.Contains(creature.GetType());
        }

        public bool TryEat(params ICreature[] victims)
        {
            var feast = new Feast(_owner, victims.Where(v => _victims.Contains(v.GetType())));
            return feast.Resolve();
        }
    }
}
