using AdventureTown.Data;
using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Data.Items
{
    public class JunkItems
    {
        private static Dictionary<int, Item> _junkItems = new Dictionary<int, Item>()
        {
            { 1, new Item() { Rarity = ItemRarity.Junk, Name = "Used Bandage", GoldValue = 1 } },
            { 2, new Item() { Rarity = ItemRarity.Junk, Name = "Broken Sword", GoldValue = 4 } },
            { 3, new Item() { Rarity = ItemRarity.Junk, Name = "Glas Shards", GoldValue = 2 } },
            { 4, new Item() { Rarity = ItemRarity.Junk, Name = "Torn off Cloth", GoldValue = 2 } },
            { 5, new Item() { Rarity = ItemRarity.Junk, Name = "Weird looking 'Egg'", GoldValue = 50 } },
            { 6, new Item() { Rarity = ItemRarity.Junk, Name = "Broken Stem", GoldValue = 1 } },
            { 7, new Item() { Rarity = ItemRarity.Junk, Name = "Old Book", GoldValue = 8 } },
            { 8, new Item() { Rarity = ItemRarity.Junk, Name = "Small Key", GoldValue = 5 } },
            { 9, new Item() { Rarity = ItemRarity.Junk, Name = "Common Quartz Crystal", GoldValue = 6 } },
            { 10, new Item() { Rarity = ItemRarity.Junk, Name = "Leather Pants", GoldValue = 10 } },
            { 11, new Item() { Rarity = ItemRarity.Junk, Name = "Small Feather", GoldValue = 2 } },
            { 12, new Item() { Rarity = ItemRarity.Junk, Name = "Broken Claw", GoldValue = 1 } },
            { 13, new Item() { Rarity = ItemRarity.Junk, Name = "Small Tusk", GoldValue = 8 } },
            { 14, new Item() { Rarity = ItemRarity.Junk, Name = "Unreadable Letter", GoldValue = 1 } },
            { 15, new Item() { Rarity = ItemRarity.Junk, Name = "Bag of Marbles", GoldValue = 3 } }
        };

        internal static Item GetRandomJunkItem()
        {
            return _junkItems[GameStorage.Random.Next(1, _junkItems.Count)];
        }

        internal static List<Item> GetRandomJunkItems(int amount)
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < amount; i++)
            {
                items.Add(_junkItems[GameStorage.Random.Next(1, _junkItems.Count)]);
            }
            return items;
        }
    }
}
