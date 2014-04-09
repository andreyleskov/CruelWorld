namespace CruelWorld
{
    using System.Collections.Generic;
    using System.Linq;

    class Feast
    {
        private readonly IEnumerable<ICreature> _predators;

        private readonly IEnumerable<ICreature> _victims;

        public Feast(IEnumerable<ICreature> predators, IEnumerable<ICreature> victims)
        {
            this._predators = predators;
            this._victims = victims;
        }

        public bool Resolve()
        {
            var fight = new Fight(this._predators, this._victims);
            fight.Resolve();
            return this._victims.All(d => d.IsDead) && this._predators.Any(a => !a.IsDead);
        }
    }
}