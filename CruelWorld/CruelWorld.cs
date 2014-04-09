using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld
{
    interface ICreature
    {
        bool IsDead { get; }
        int HitPoints { get; set; }

        //produce some damage
        int Fight();

        void Suffer(int amount);
    }

        class Sheep: ICreature
        {
            public bool IsDead { get; private set; }
            public int HitPoints { get; set; }
            public int Fight()
            {
                return 1;
            }
        }

        abstract class Humanoid : ICreature
        {
            public bool IsDead { get; protected set; }
            public int HitPoints { get; set; }
            public abstract int Fight();
            protected readonly float WeaponCoefficient;

            protected Humanoid (float weaponCoeffictient)
            {
                WeaponCoefficient = weaponCoeffictient;
            }
        }

        class Ogre:Humanoid
        {
            public Ogre(float weaponCoeffictient) : base(weaponCoeffictient)
            {
            }

            public override int Fight()
            {
                return  (int)(10*WeaponCoefficient);
            }
        }

        class Goblin : Humanoid
        {
            public Goblin(float weaponCoeffictient)
                : base(weaponCoeffictient)
            {
            }

            public override int Fight()
            {
                return (int)(3 * WeaponCoefficient);
            }
        }


        class Fight
        {
            private ICreature[] Attackers;
            private ICreature[] Defenders;

            public Fight(IEnumerable<ICreature> attackers, IEnumerable<ICreature> defenders)
            {
                Defenders = defenders.ToArray();
                Attackers = attackers.ToArray();
            }

            public void Resolve()
            {
                Resolve(Attackers, Defenders);
                Resolve(Defenders, Attackers);
            }

            private void Resolve(IEnumerable<ICreature> damageDealers, ICreature[] damageTakers)
            {
                var attackersPower = damageDealers.Sum(a => a.Fight());

                while (attackersPower > 0 && damageTakers.Any(d => !d.IsDead))
                {
                    var defender = Defenders.First(d => !d.IsDead);
                    defender.HitPoints = Math.Max(0, defender.HitPoints - attackersPower);
                    attackersPower = Math.Max(0, attackersPower - defender.HitPoints);
                }
            }
        }

        class Feast
        {
            private IEnumerable<ICreature> Attackers;
            private IEnumerable<ICreature> Defenders;

            public Feast(IEnumerable<ICreature> attackers, IEnumerable<ICreature> defenders)
            {
                Defenders = defenders;
                Attackers = attackers;
            }

            public bool HaveDefendersBeenEaten()
            {
                var fight = new Fight(Attackers, Defenders);
                fight.Resolve();
                return Defenders.All(d => d.IsDead) && Attackers.Any(a => !a.IsDead);
            }
        }

        [Test]
        public void GoblinEatesSheep()
        {
            var goblin = new Goblin(1.0F);
            var sheep = new Sheep();
            var fight = new Fight(new[] {goblin}, new[] {sheep});
            fight.Resolve();
            Assert.AreEqual(true, sheep.IsDead);
            Assert.AreEqual(false, goblin.IsDead);
        }

        [Test]
        public void OgreEatesSheep()
        {
            var ogre = new Ogre(1.0F);
            var sheep = new Sheep();
            var fight = new Fight(new[] { ogre }, new[] { sheep });
            fight.Resolve();
            Assert.AreEqual(true, sheep.IsDead);
            Assert.AreEqual(false, ogre.IsDead);
        }

        [Test]
        public void TwoGoblins_and_a_sheep()
        {
            var goblinA = new Goblin(1.0F);
            var goblinB = new Goblin(1.2F);
            var sheep = new Sheep();
            var fight = new Fight(new[] { goblinA }, new[] { goblinB });
            fight.Resolve();
            Assert.AreEqual(true, goblinA.IsDead);
            Assert.AreEqual(false, goblinB.IsDead);

            var fight = new Fight(new[] { goblinA }, new[] { goblinB });
            Assert.AreEqual(true, sheep.IsDead);
            Assert.AreEqual(false, ogre.IsDead);
        }




        [Test]
        public void WordReverse()
        {
            string phrase = "From fairest creatures we desire increase, That thereby beauty's rose might never die";

            string reverse = phrase.Split(' ').Reverse().Aggregate("", (str, newWold) => str + " " + newWold);
        }
}
