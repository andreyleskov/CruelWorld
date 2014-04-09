namespace CruelWorld.Creatures
{
    public class Sheep: MortalCreature
    {
        public Sheep(): base(2)
        {
        }

        public override int Fight()
        {
            return 1;
        }
    }
}
