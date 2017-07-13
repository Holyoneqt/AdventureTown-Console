using AdventureTown.Data;
using AdventureTown.Models.Entities;
using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Screens.Character
{
    public class BackpackScreen : IScreen
    {
        private Player _player;

        public string HandleInput(ConsoleKeyInfo input)
        {

            return "";
        }

        public void OnClose()
        {

        }

        public void OnLoad()
        {
            _player = GameStorage.Get().Player;
        }

        public void Render()
        {
            Console.WriteLine("Items:\n");
            foreach (Item item in _player.Backpack)
            {
                Console.WriteLine($"{item.Name} ({item.GoldValue} Gold) - {item.Rarity.ToString()}");
            }
        }
    }
}
