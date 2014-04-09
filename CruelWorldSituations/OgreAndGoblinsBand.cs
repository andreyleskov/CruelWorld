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
    //3) Огр попытался съесть группу гоблинов, но не смог.
    [TestFixture]
    public class OgreAndGoblinsBand
    {
        private bool _eatResult;

        private Ogre _ogre;

        private ICreature[] _goblinBand;

        [SetUp]
        public void Given_ogre_and_goblinBand_When_ogre_fights()
        {
            _ogre = new Ogre();
            this._goblinBand = new ICreature[] { new Goblin(), new Goblin(), new Goblin() };

            this._eatResult = _ogre.TryEat(_goblinBand);
        }

        [Test]
        public void OgreIsAlive()
        {
            Assert.True(_ogre.IsAlive);
        }

        [Test]
        public void Goblins_not_been_eaten()
        {
            Assert.False(_eatResult);
        }

        [Test]
        public void Any_goblin_remains_alive()
        {
            Assert.True(_goblinBand.Any(g =>g.IsAlive));
        }
    }
}
