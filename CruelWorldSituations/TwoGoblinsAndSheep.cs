using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorldSituations
{
    using CruelWorld;

    using NUnit.Framework;
    /// <summary>
    /// 2) Два гоблина подрались из-за овцы. Победитель съел овцу.
    /// </summary>
    [TestFixture]
    public class TwoGoblinsAndSheep
    {
        private Goblin _winner;

        private bool _eatResult;

        private Sheep _sheep;

        private Goblin _goblinB;

        private Goblin _goblinA;

        [SetUp]
        public void Given_two_goblin_and_a_sheep_when_goblin_fight_and_winner_eats_sheep()
        {
            this._goblinA = new Goblin();
            this._goblinA.SetWeapon(new RustySword());

            this._goblinB = new Goblin();
            this._sheep = new Sheep();

            this._goblinA.TryFight(this._goblinB);

            this._winner = this._goblinA.IsAlive ? this._goblinA : this._goblinB;

            this._eatResult = this._winner.TryEat(this._sheep);
        }

        [Test]
        public void Winner_is_goblin_A()
        {
            Assert.AreEqual(_goblinA,_winner);
        }

        [Test]
        public void Winner_is_alive()
        {
            Assert.True(_winner.IsAlive);
        }

        [Test]
        public void Sheep_eaten()
        {
            Assert.True(_eatResult);
        }
        [Test]
        public void Sheep_is_dead()
        {
            Assert.True(_sheep.IsDead);
        }
    }
}
