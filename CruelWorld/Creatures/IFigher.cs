namespace CruelWorld.Creatures
{
    interface IFigher
    {
        bool TryFight(params ICreature[] opponents);
    }
}