﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Abilities
{
    using CruelWorld.Creatures;
    using CruelWorld.Interactions;

    class PredatorAbility : IPredator
    {
        private readonly IEnumerable<ICreature> _owner;

        private readonly HashSet<Type> _victims;
        private readonly Type[] _victimsArray;

        public PredatorAbility(IEnumerable<ICreature> owner, params Type[] victims)
        {
            this._owner = owner;
            _victimsArray = victims;
            _victims = new HashSet<Type>(victims);
        }

        public bool CanEat(ICreature creature)
        {
            return _victims.Contains(creature.GetType());
        }

        public Type[] Victims
        {
            get
            {
                return _victimsArray;
            }
        }

        public bool TryEat(params ICreature[] victims)
        {
            var feast = new Feast(_owner, victims.Where(v => _victims.Contains(v.GetType())));
            return feast.Resolve();
        }
    }
}
