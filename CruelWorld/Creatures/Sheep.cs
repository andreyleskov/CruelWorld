namespace CruelWorld.Creatures
{
    public class Sheep: MortalCreature
    {
        public Sheep(): base(2)
        {
        }

        public override int Strength
        {
            get { return 1; }
        }
    }
}
