using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Data.Items
{
    public class NormalItems
    {
        private static Dictionary<int, Item> _normalItems = new Dictionary<int, Item>()
        {
            { 1, new Item() { Rarity = ItemRarity.Normal, Name = "Wood", GoldValue = 3 } },
            { 2, new Item() { Rarity = ItemRarity.Normal, Name = "Bundle of Herbs", GoldValue = 3 } },
            { 3, new Item() { Rarity = ItemRarity.Normal, Name = "Cloth", GoldValue = 3 } },
            { 4, new Item() { Rarity = ItemRarity.Normal, Name = "Piece of Paper", GoldValue = 3 } },
            { 5, new Item() { Rarity = ItemRarity.Normal, Name = "Bottle", GoldValue = 3 } }
        };

        internal static Item GetRandomNormalItem()
        {
            return _normalItems[GameStorage.Random.Next(1, _normalItems.Count)];
        }

        internal static List<Item> GetRandomNormalItems(int amount)
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < amount; i++)
            {
                items.Add(_normalItems[GameStorage.Random.Next(1, _normalItems.Count)]);
            }
            return items;
        }
    }
}
