using AdventureTown.Data;
using AdventureTown.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Screens
{
    public class CharacterScreen : IScreen
    {
        private Player _player;

        public string HandleInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.C:
                    ScreenManager.GetInstance().ChangeScreen(ScreenContainer.CharacterInfo);
                    return "";
                case ConsoleKey.B:
                    ScreenManager.GetInstance().ChangeScreen(ScreenContainer.Backpack);
                    return "";
                case ConsoleKey.L:
                    ScreenManager.GetInstance().ChangeScreen(ScreenContainer.QuestLog);
                    return "";
                default:
                    break;
            }
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
            Console.WriteLine("C - Detailed Character Information");
            Console.WriteLine("B - Backpack");
            Console.WriteLine("L - Quest Log");
        }
    }
}
