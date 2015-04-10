namespace CruelWorld.Interactions
{
    using System.Collections.Generic;
    using System.Linq;

    using CruelWorld.Creatures;

    class Fight
    {
        private readonly ICreature[] _attackers;
        private readonly ICreature[] _defenders;

        public Fight(IEnumerable<ICreature> attackers, IEnumerable<ICreature> defenders)
        {
            this._defenders = defenders.ToArray();
            this._attackers = attackers.ToArray();
        }

        public bool Resolve()
        {
            this.Resolve(this._attackers, this._defenders);
            this.Resolve(this._defenders, this._attackers);
            return this._attackers.Any(a => a.IsAlive) && this._defenders.All(d => d.IsDead);
        }

        private void Resolve(IEnumerable<ICreature> damageDealers, ICreature[] damageTakers)
        {
            var attackersPower = damageDealers.Sum(a => a.Strength);

            while (attackersPower > 0 && damageTakers.Any(d => !d.IsDead))
            {
                var defender = damageTakers.First(d => !d.IsDead);
                var hp = defender.HitPoints;
                defender.Suffer(attackersPower);
                attackersPower -= hp;
            }
        }
    }
}