using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorldSituations
{
    using CruelWorld;
    using CruelWorld.Creatures;
    using CruelWorld.Weapons;

    using NUnit.Framework;
    /// <summary>
    /// 5) Два огра попытались съесть гоблина с волшебным мечом, но не смогли.
    /// </summary>
    [TestFixture]
    public class OgreBandVanishedByMagic
    {
        private bool _goblinsAreEaten;

        private Goblin _goblin;

        private Band _ogreBand;

        [SetUp]
        public void Given_ogreBand_and_pumpedUpGoblin_when_eat()
        {
            this._ogreBand = new Band(new Ogre(), new Ogre());
            this._goblin = new Goblin();
            this._goblin.TakeWeapon(new MagicSword());

            this._goblinsAreEaten = this._ogreBand.TryEat(this._goblin);
        }

        [Test]
        public void Goblin_is_heroic_dead()
        {
            Assert.True(_goblin.IsDead);
        }

        [Test]
        public void Goblin_is_not_eaten()
        {
            Assert.False(_goblinsAreEaten);
        }

        [Test]
        public void Ogres_are_dead()
        {
            Assert.True(_ogreBand.All(o => o.IsDead));
        }
    }
}
