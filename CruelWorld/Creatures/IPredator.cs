namespace CruelWorld
{
    using System;

    public interface IPredator
    {
        bool CanEat(ICreature creature);
        Type[] Victims { get; }
        bool TryEat(params ICreature[] victims);
    }
}