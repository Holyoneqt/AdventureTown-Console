using AdventureTown.Data;
using AdventureTown.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown
{
    public class AdventureTownGame
    {
        public void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the AdventureTown Game!");
            Console.WriteLine("What's your name?");

            Console.Write("==> ");
            GameStorage.Get().Player.Name = Console.ReadLine();

            Console.WriteLine($"Ok {GameStorage.Get().Player.Name}, here we go!");
            Console.WriteLine("Press any key to Start your ADVENTURE...");
            Console.ReadKey();

            GameLoop();
        }

        private void GameLoop()
        {
            ScreenManager screenManager = ScreenManager.GetInstance();
            string answer = "";
            while (!GameStorage.Get().GameOver)
            {
                screenManager.Render();

                Console.WriteLine();
                if (!string.IsNullOrEmpty(answer))
                    Console.WriteLine(answer);
                Console.Write("==> ");
                answer = screenManager.HandleInput(Console.ReadKey());
            }
        }
    }
}
