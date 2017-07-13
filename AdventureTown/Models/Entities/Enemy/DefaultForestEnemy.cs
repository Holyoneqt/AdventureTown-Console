using AdventureTown.Data;
using AdventureTown.Data.Items;
using AdventureTown.Models.Gameplay.Attributes;
using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Entities.Enemy
{
    public class DefaultForestEnemy : EntityEnemy
    {
        private string[] _possibleNames = { "Swamp Witch", "Elder Darkskin-Tree", "Undead Wanderer", "Wolf", "Unholy Fairy" };

        public DefaultForestEnemy() : base()
        {
            Name = _possibleNames[GameStorage.Random.Next(_possibleNames.Length)];
            Attributes.Set(AttributeType.Stamina, 8);
            Attributes.Set(AttributeType.Power, 3);
            Attributes.Set(AttributeType.Lethality, 0);
            Attributes.Set(AttributeType.Armor, 5);

            GoldValue = 5;
            Loot = ItemFactory.GenereateLoot(this);

            CurrentHealth = MaxHealth;
        }
    }
}
