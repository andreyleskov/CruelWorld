using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Abilities
{
    class WeaponUsingAbility
    {
        private readonly ICreature _creature;
        private readonly IWeapon _weapon;

        public WeaponUsingAbility(ICreature creature, IWeapon weapon)
        {
            this._weapon = weapon;
            this._creature = creature;
        }

        public int Fight()
        {
            return _creature.Fight() + _weapon.FightBonus;
        }
    }
}
