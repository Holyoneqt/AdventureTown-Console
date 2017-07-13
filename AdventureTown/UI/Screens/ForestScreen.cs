using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Screens
{
    public class ForestScreen : IScreen
    {
        private bool _search;
        private string _searchText;

        public string HandleInput(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.S)
                _search = true;
            else
                _search = false;
            return "";
        }

        public void OnClose()
        {

        }

        public void OnLoad()
        {
            _search = false;
        }

        public void Render()
        {
            Console.WriteLine("You are in the Forest!");
            Console.WriteLine("What do you want to do? => 'Q' to go back to town, 'S' to search the Forest");

            Console.WriteLine("\n" + _searchText);
            if (_search)
            {
                double whatNext = new Random().NextDouble();
                if (whatNext <= 0.10)
                    _searchText = "You would have gotten an Treasure... but its not implemented yet x)";
                else if (whatNext <= 0.70)
                    ScreenManager.GetInstance().ChangeScreen(ScreenContainer.ForestFight);
                else
                   _searchText = "You found nothing..";
            }
        }
    }
}
