using AdventureTown.Models.Entities.Enemy;
using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Data.Items
{
    public class ItemFactory
    {
        public static List<Item> GenereateLoot(EntityEnemy enemy)
        {
            List<Item> loot = new List<Item>();
            int lootItems = GameStorage.Random.Next(3);
            for (int i = 0; i < lootItems; i++)
            {
                double itemRandom = GameStorage.Random.NextDouble();
                
                if (itemRandom <= 0.1)
                    loot.Add(new Item() { Rarity = ItemRarity.Rare, Name = "A Rare Item", GoldValue = 0 });
                else if (itemRandom <= 0.11)
                    loot.Add(new Item() { Rarity = ItemRarity.Special, Name = "A Special Item", GoldValue = 0 });
                else if (itemRandom <= 0.51)
                    loot.Add(NormalItems.GetRandomNormalItem());
                else
                    loot.Add(JunkItems.GetRandomJunkItem());
            }

            return loot;
        }
    }
}
