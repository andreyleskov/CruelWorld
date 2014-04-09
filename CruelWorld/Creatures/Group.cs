namespace CruelWorld.Creatures
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using CruelWorld.Abilities;

    public class Group : IFigher, IEnumerable<ICreature>
    {
        protected readonly ICreature[] _creatures;

        private readonly FightAbility _fightAbility;
        public Group(params ICreature[] creatures)
        {
            this._creatures = creatures;
            this._fightAbility = new FightAbility(this.ToArray());
        }

        public bool TryFight(params ICreature[] opponents)
        {
            return this._fightAbility.TryFight(opponents);
        }

        public IEnumerator<ICreature> GetEnumerator()
        {
            return ((IEnumerable<ICreature>)_creatures).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._creatures.GetEnumerator();
        }
    }
}