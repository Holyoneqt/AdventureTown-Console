using AdventureTown.Data;
using AdventureTown.Models.Gameplay.Quests;
using AdventureTown.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Screens.Character
{
    public class QuestLogScreen : IScreen
    {
        private List<Quest> _quests;
        private Quest _selectedQuest;

        public string HandleInput(ConsoleKeyInfo input)
        {
            if (_selectedQuest != null && input.Key == ConsoleKey.X)
                _selectedQuest = null;


            int selection = ConsoleKeyParser.GetIntFromKey(input);
            if (selection >= 1 && selection <= _quests.Count)
            {
                _selectedQuest = _quests[selection - 1];
            }

            return "";
        }

        public void OnClose()
        {

        }

        public void OnLoad()
        {
            _quests = GameStorage.Get().Player.Quests;
        }

        public void Render()
        {
            if(_selectedQuest == null)
            {
                if(_quests.Count == 0)
                    Console.WriteLine("You have no Quests!\n");

                for (int i = 0; i < _quests.Count; i++)
                {
                    Console.WriteLine($"{i+1}: {_quests[i].Name} - {_quests[i].Type}");
                }
            }
            else
            {
                Console.WriteLine($"Details of Quest '{_selectedQuest.Name}'");
                Console.WriteLine($"Type: {_selectedQuest.Type}");
                if(!_selectedQuest.IsFinished)
                    Console.WriteLine($"Requirements: {_selectedQuest.Objective.Description} {_selectedQuest.Objective.Current}/{_selectedQuest.Objective.Required}");
                else
                    Console.WriteLine("Requirements: Finished! Go back to the Tavern to complete the Quest.");

                Console.WriteLine("\n'X' to go back to the Quest-Log");
            }
        }
    }
}
