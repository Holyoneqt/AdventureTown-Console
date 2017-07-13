using AdventureTown.UI.Screens;
using AdventureTown.UI.Screens.Character;
using AdventureTown.UI.Screens.Forest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI
{
    public class ScreenContainer
    {
        public static IScreen Town = new TownScreen();
        public static IScreen Tavern = new TavernScreen();

        public static IScreen Character = new CharacterScreen();
        public static IScreen CharacterInfo = new CharacterInfoScreen();
        public static IScreen Backpack = new BackpackScreen();
        public static IScreen QuestLog = new QuestLogScreen();

        public static IScreen Forest = new ForestScreen();
        public static IScreen ForestFight = new FightScreen();
    }
}
