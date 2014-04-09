namespace CruelWorld
{
    public class Goblin : Humanoid
    {

        public Goblin(): base(3, typeof(Sheep), typeof(Goblin))
        {
        }

        protected override int BaseFightPower
        {
            get
            {
                return 1;
            }
        }
    }
}