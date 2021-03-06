﻿using AdventureTown.Data;
using AdventureTown.Models.Gameplay.Attributes;
using AdventureTown.Models.Gameplay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Entities
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public AttributeSet Attributes { get; set; }

        public double MaxHealth { get { return Attributes.Get(AttributeType.Stamina).Value * 10; } }

        private double _currHealth;
        public double CurrentHealth { get { return _currHealth; } set { _currHealth = value; } }

        public bool IsDead { get { return _currHealth <= 0; } }

        public Entity()
        {
            Attributes = new AttributeSet();
        }

        public AttackReport Attack(Entity target)
        {
            DamageCalculator dmgCalc = new DamageCalculator(this, target);
            double damage = dmgCalc.CalculateDamage();
            target.CurrentHealth -= damage;

            return new AttackReport()
            {
                DamageSource = this,
                Target = target,
                DamageDealt = damage,
                IsCriticalDamage = dmgCalc.IsCriticalDamage
            };
        }
    }
}
