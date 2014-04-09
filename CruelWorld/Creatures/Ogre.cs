namespace CruelWorld
{
    using System;

    public class Ogre : Humanoid
    {
        public Ogre(): base(10, typeof(Goblin),typeof(Sheep))
        {
        }

        protected override int BaseFightPower
        {
            get
            {
                return 5;
            }
        }
    }
}