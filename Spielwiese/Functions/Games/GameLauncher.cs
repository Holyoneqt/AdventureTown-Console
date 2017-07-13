using AdventureTown;
using Spielwiese.Util.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spielwiese.Functions.Games
{
    public class GameLauncher
    {
        private AdventureTownGame _game;

        public GameLauncher()
        {
            
        }
        
        [Command("s")]
        public void LaunchNewGame()
        {
            _game = new AdventureTownGame();
            _game.StartNewGame();
        }
    }
}
