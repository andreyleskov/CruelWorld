﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorldSituations
{
    using CruelWorld;

    using NUnit.Framework;

    /// <summary>
    /// 1) Гоблин съел овцу
    /// </summary>
    [TestFixture]
    class GoblinEatsSheep
    {
        private Goblin goblin;
        private Sheep sheep;
        private bool sheepEaten;

        [SetUp]
        public void GivenGoblinAndASheep()
        {
            this.goblin = new Goblin();
            goblin.SetWeapon(new Club());
            this.sheep = new Sheep();
            this.sheepEaten = goblin.TryEat(sheep);
        }

        [Test]
        public void Goblin_succesfully_eates_sheep()
        {
            Assert.True(sheepEaten);
        } 
        
        [Test]
        public void Sheep_became_dead()
        {
            Assert.True(sheep.IsDead);
        }
        
        [Test]
        public void Goblin_remains_alive()
        {
            Assert.True(goblin.IsAlive);
        }
    }
}