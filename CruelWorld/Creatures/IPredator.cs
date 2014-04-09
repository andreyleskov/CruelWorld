namespace CruelWorld
{
    interface IPredator
    {
        bool CanEat(ICreature creature);

        bool TryEat(params ICreature[] victims);
    }
}