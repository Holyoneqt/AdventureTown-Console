using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Entities.Enemy
{
    public class EntityEnemy : Entity
    {
        public int GoldValue { get; set; }

        public List<Item> Loot { get; internal set; }

        public EntityEnemy() : base()
        {
            Loot = new List<Item>();
        }
    }
}
