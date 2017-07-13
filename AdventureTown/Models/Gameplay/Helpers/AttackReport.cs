using AdventureTown.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Gameplay.Helpers
{
    public class AttackReport
    {
        public Entity DamageSource { get; set; }
        public Entity Target { get; set; }
        public double DamageDealt { get; set; }
        public bool IsCriticalDamage { get; set; }
    }
}
