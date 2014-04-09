using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Creatures
{
    using CruelWorld.Abilities;

    using NUnit.Framework.Constraints;

    public class Band : Group, IPredator
    {
        public Band(params ICreature[] creatures):base(creatures)
        {
            ICreature[] predatorCreatures = creatures.Where(c =>c is IPredator).ToArray();

            _predatorAbility = new PredatorAbility(predatorCreatures, 
                                                   predatorCreatures.Cast<IPredator>()
                                                        .SelectMany(p =>p.Victims)
                                                        .Distinct()
                                                        .ToArray());
        }

        private readonly PredatorAbility _predatorAbility;

        public bool CanEat(ICreature creature)
        {
            return _predatorAbility.CanEat(creature);
        }

        public Type[] Victims 
        { 
            get
            {
                return _predatorAbility.Victims;
            } 
        }

        public bool TryEat(params ICreature[] victims)
        {
            return _predatorAbility.TryEat(victims);
        }
    }
}
