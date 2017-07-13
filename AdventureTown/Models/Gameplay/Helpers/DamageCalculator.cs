using AdventureTown.Data;
using AdventureTown.Models.Entities;
using AdventureTown.Models.Gameplay.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Gameplay.Helpers
{
    public class DamageCalculator
    {
        private Entity _damageSource;
        private Entity _damageTarget;

        public bool IsCriticalDamage { get; private set; }

        public DamageCalculator(Entity source, Entity target)
        {
            _damageSource = source;
            _damageTarget = target;
            IsCriticalDamage = (GameStorage.Random.Next(100) < _damageSource.Attributes.Get(AttributeType.Lethality).Value);
        }

        public double CalculateDamage()
        {
            double powMod = Constants.PowerDamageConstant;
            if (IsCriticalDamage)
                powMod *= 2;

            double dmg = ((_damageSource.Attributes.Get(AttributeType.Power).Value * powMod) * ArmorDamageModifier());

            return dmg;
        }

        private double ArmorDamageModifier()
        {
            return (100 / (100 + _damageTarget.Attributes.Get(AttributeType.Armor).Value));
        }
    }
}
