namespace CruelWorld
{
    using System;

    public abstract class MortalCreature : ICreature
    {
        public bool IsDead { get; private set; }
        public bool IsAlive{ get
        {
            return !IsDead;
        }}

        public int HitPoints { get; protected set; }
        public abstract int FightPower();

        protected MortalCreature(int totalHp)
        {
            IsDead = false;
            HitPoints = totalHp;
        }

        public int Suffer(int amount)
        {
            int resultHp = Math.Max(0, HitPoints - amount);
            int sufferAmount = HitPoints - resultHp;
            HitPoints = resultHp;

            IsDead = HitPoints <= 0;

            return sufferAmount;
        }

    }
}