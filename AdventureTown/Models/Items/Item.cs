using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Items
{
    public class Item
    {
        public ItemRarity Rarity { get; set; }
        public string Name { get; set; }
        public int GoldValue { get; set; }
    }
}
