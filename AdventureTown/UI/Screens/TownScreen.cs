using System;

namespace AdventureTown.UI.Screens
{
    internal class TownScreen : IScreen
    {
        public string HandleInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    ScreenManager.GetInstance().ChangeScreen(ScreenContainer.Character);
                    return "";
                case ConsoleKey.D2:
                    ScreenManager.GetInstance().ChangeScreen(ScreenContainer.Tavern);
                    return "";
                case ConsoleKey.D3:
                    ScreenManager.GetInstance().ChangeScreen(ScreenContainer.Forest);
                    return "";
                default:
                    return "Enter a valid option!";
            }
        }

        public void OnClose()
        {

        }

        public void OnLoad()
        {
            
        }

        public void Render()
        {
            Console.WriteLine("Welcome to the Town!");
            Console.WriteLine("Choose what you do next:");
            Console.WriteLine("1: Character - All Informations about your Character");
            Console.WriteLine("2: Tavern - Get new Quests");
            Console.WriteLine("3: Forest - The Forest is full of danger.");
        }
    }
}