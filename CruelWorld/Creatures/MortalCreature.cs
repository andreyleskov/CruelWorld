namespace CruelWorld.Creatures
{
    using System;

    public abstract class MortalCreature : ICreature
    {
        public bool IsDead { get; private set; }
        public bool IsAlive{ get
        {
            return !this.IsDead;
        }}

        public int HitPoints { get; protected set; }
        public abstract int Strength { get; }

        protected MortalCreature(int totalHp)
        {
            this.IsDead = false;
            this.HitPoints = totalHp;
        }

        public int Suffer(int amount)
        {
            int resultHp = Math.Max(0, this.HitPoints - amount);
            int sufferAmount = this.HitPoints - resultHp;
            this.HitPoints = resultHp;

            this.IsDead = this.HitPoints <= 0;

            return sufferAmount;
        }

    }
}