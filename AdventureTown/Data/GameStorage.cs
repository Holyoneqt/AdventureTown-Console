using AdventureTown.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Data
{
    public class GameStorage
    {
        public static Random Random = new Random();

        private static GameStorage _instance;

        public bool GameOver { get; set; }
        public Player Player { get; set; }

        private GameStorage()
        {
            GameOver = false;
            Player = new Player();
        }

        public static GameStorage Get()
        {
            if (_instance == null)
                _instance = new GameStorage();
            return _instance;
        }
    }
}
