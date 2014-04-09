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
    /// <summary>
    /// 5) Два огра попытались съесть гоблина с волшебным мечом, но не смогли.
    /// </summary>
    [TestFixture]
    public class OgreBandVanishedByMagic
    {
        [SetUp]
        public void Given_ogreBand_and_pumpedUpGoblin_when_eat()
        {
            var ogreBand = new Band(new Ogre(), new Ogre());
            var goblin = new Goblin();
        }
    }
}
