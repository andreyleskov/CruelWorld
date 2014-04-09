namespace CruelWorld
{
    interface IFigher
    {
        bool TryFight(params ICreature[] opponents);
    }
}