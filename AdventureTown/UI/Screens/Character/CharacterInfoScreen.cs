using AdventureTown.Data;
using AdventureTown.Models.Entities;
using AdventureTown.Models.Gameplay.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Screens.Character
{
    class CharacterInfoScreen : IScreen
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
            Console.WriteLine($"All Information about {_player.Name}");
            Console.WriteLine($"\nLevel: {_player.Level}");
            Console.WriteLine($"XP: {_player.Experience}/{_player.ExperienceToNextLevelUp}");
            Console.WriteLine($"\nGold: {_player.Gold}");
            Console.WriteLine("\nAttributes:");
            Console.WriteLine($" -Stamina: {_player.Attributes.Get(AttributeType.Stamina).Value}");
            Console.WriteLine($" -Power: {_player.Attributes.Get(AttributeType.Power).Value}");
            Console.WriteLine($" -Lethality: {_player.Attributes.Get(AttributeType.Lethality).Value}");
        }
    }
}
