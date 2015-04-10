using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorldSituations
{
    using CruelWorld;
    using CruelWorld.Creatures;

    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    [TestFixture]
    public class AlliesAgainsOgres
    {
        private bool _ogresBeaten;

        private Band _ogreBand;

        private Group _alliesHorde;

        [SetUp]
        public void Given_ogreBand_and_goblinSheepGroup_when_fight()
        {
            this._ogreBand = new Band(new Ogre(), new Ogre());
            this._alliesHorde = new Group(new Goblin(),
                                          new Goblin(),
                                          new Goblin(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep(),
                                          new Sheep());

            this._ogresBeaten = this._alliesHorde.TryFight(this._ogreBand.ToArray());
        }

        [Test]
        public void AlliesWin()
        {
            Assert.True(_ogresBeaten);
        }


        [Test]
        public void AlliesAlive()
        {
            Assert.True(_alliesHorde.Any(a => a.IsAlive));
        }


        [Test]
        public void OgresDead()
        {
            Assert.True(_ogreBand.All(a => a.IsDead));
        }
    }
}
