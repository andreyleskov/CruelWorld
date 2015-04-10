using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorldSituations
{
    using System.Threading;

    using CruelWorld;
    using CruelWorld.Creatures;

    using NUnit.Framework;
           
    /// <summary>
    ///  4) Группа огров успешно съели группу гоблинов.
    /// </summary>
    [TestFixture]
    public class OgreBandEatsGoblinBand
    {
        private bool _goblinsEaten;

        private ICreature[] _goblinBand;

        private Band _ogreBand;

        [SetUp]
        public void Given_ogreBand_and_goblinBand_when_eats()
        {
            this._ogreBand = new Band(new Ogre(), new Ogre());
            this._goblinBand = new ICreature[]{new Goblin(), new Goblin(), new Goblin()};

            this._goblinsEaten = this._ogreBand.TryEat(this._goblinBand);
        }


        [Test]
        public void Goblins_are_eaten()
        {
            Assert.True(_goblinsEaten);
        }

        [Test]
        public void Goblins_are_dead()
        {
            Assert.True(_goblinBand.All(g => g.IsDead));
        }

        [Test]
        public void Ogre_remains_alive()
        {
            Assert.True(_ogreBand.Any(g => g.IsAlive));
        }
    }
}
