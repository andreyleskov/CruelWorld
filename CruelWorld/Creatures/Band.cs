using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Creatures
{
    using System.Collections;

    using CruelWorld.Abilities;

    public class Band : Group, IPredator
    {
        public Band(params Goblin[] creatures)
        {
            
        }

        public bool CanEat(ICreature creature)
        {
            throw new NotImplementedException();
        }

        public bool TryEat(params ICreature[] victims)
        {
            throw new NotImplementedException();
        }
    }

    public class Group : IFigher, IEnumerable<ICreature>
    {
        private readonly ICreature[] _creatures;

        private readonly FightAbility _fightAbility;
        public Group(params ICreature[] creatures)
        {
            this._creatures = creatures;
            _fightAbility = new FightAbility(this.ToArray());
        }

        public bool TryFight(params ICreature[] opponents)
        {
           return _fightAbility.TryFight(opponents);
        }

        public IEnumerator<ICreature> GetEnumerator()
        {
            return (IEnumerator<ICreature>)_creatures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _creatures.GetEnumerator();
        }
    }
}
