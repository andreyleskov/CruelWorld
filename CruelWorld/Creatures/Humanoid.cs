namespace CruelWorld.Creatures
{
    using System;

    using CruelWorld.Abilities;
    using CruelWorld.Weapons;

    public abstract class Humanoid : MortalCreature, IPredator, IWeaponUser, IFigher
    {
        private IWeapon _weapon = new BareHands();
        private readonly PredatorAbility _predatorAbility;
        private readonly FightAbility _fightAbility;

        protected Humanoid(int hp, params Type[] victims):base(hp)
        {
            this._predatorAbility = new PredatorAbility(new[] { this }, victims);
            this._fightAbility = new FightAbility(this);
        }

        protected abstract int BaseFightPower { get; }

        public override int Strength
        {
            get { return this.BaseFightPower + this._weapon.FightBonus; }
        }

        public bool CanEat(ICreature creature)
        {
            return this._predatorAbility.CanEat(creature);
        }

        public Type[] Victims
        {
            get
            {
                return this._predatorAbility.Victims;
            }
        }

        public bool TryEat(params ICreature[] victims)
        {
            return this._predatorAbility.TryEat(victims);
        }

        public void TakeWeapon(IWeapon weapon)
        {
            this._weapon = weapon;
        }

        public bool TryFight(params ICreature[] opponents)
        {
            return this._fightAbility.TryFight(opponents);
        }
    }
}