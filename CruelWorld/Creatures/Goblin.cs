namespace CruelWorld
{
    using CruelWorld.Abilities;
    using CruelWorld.Weapons;

    public class Goblin : MortalCreature, IPredator, IWeaponUser, IFigher
    {
        private IWeapon _weapon = new NatureWeapon();
        private readonly PredatorAbility _predatorAbility;

        private readonly FightAbility _fightAbility;

        public Goblin()
        {
            this._predatorAbility = new PredatorAbility(new[]{this}, typeof(Sheep), typeof(Goblin) );
            this._fightAbility = new FightAbility(this);
            HitPoints = 3;
        }

        public override int FightPower()
        {
            return 1 + _weapon.FightBonus;
        }

        public bool CanEat(ICreature creature)
        {
            return _predatorAbility.CanEat(creature);
        }

        public bool TryEat(params ICreature[] victims)
        {
            return _predatorAbility.TryEat(victims);
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public bool TryFight(params ICreature[] opponents)
        {
            return _fightAbility.TryFight(opponents);
        }
    }
}