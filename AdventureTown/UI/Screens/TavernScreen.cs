using AdventureTown.Data;
using AdventureTown.Models.Gameplay.Quests;
using AdventureTown.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Screens
{
    public class TavernScreen : IScreen
    {
        private GameStorage _data;
        private List<Quest> _availableQuests;

        public TavernScreen()
        {
            _data = GameStorage.Get();
            _availableQuests = new List<Quest>();
        }

        public string HandleInput(ConsoleKeyInfo input)
        {
            int number = ConsoleKeyParser.GetIntFromKey(input);
            if (number >= 1 && number <= _availableQuests.Count)
            {
                _data.Player.Quests.Add(_availableQuests[number - 1]);
                _availableQuests.RemoveAt(number - 1);
            }

            if (input.Key == ConsoleKey.C)
            {
                List<Quest> completed = GameStorage.Get().Player.Quests.Where(q => q.IsFinished).ToList();
                if (completed.Count > 0)
                {
                    foreach (Quest q in completed)
                    {
                        GameStorage.Get().Player.TurnInQuest(q);
                    }
                }
                else
                    return "No Completed Quests!";
            }
            return "";
        }

        private void GenerateQuests()
        {
            int questsToGenerate = Constants.MaximumQuestAvailable - _availableQuests.Count - _data.Player.Quests.Count;

            for (int i = 0; i < questsToGenerate; i++)
            {
                double questTypePercent = GameStorage.Random.NextDouble();
                QuestType qType;
                if (questTypePercent <= 0.00)
                    qType = QuestType.Legendary;
                else if (questTypePercent <= 0.08)
                    qType = QuestType.Heroic;
                else if (questTypePercent <= 0.20)
                    qType = QuestType.Dungeon;
                else
                    qType = QuestType.Normal;

                _availableQuests.Add(new Quest(qType));
            }
        }

        public void OnClose()
        {
        }

        public void OnLoad()
        {
            GenerateQuests();
        }

        public void Render()
        {
            if (GameStorage.Get().Player.Quests.Count == 0)
                Console.WriteLine("You have no current Quest!");

            if(_availableQuests.Count > 0)
            {
                Console.WriteLine("\nChoose a Quest!");
                for (int i = 0; i < _availableQuests.Count; i++)
                {
                    Quest q = _availableQuests[i];
                    Console.WriteLine($"{i + 1}: {q.Name} - {q.Type}");
                }
            }
            else
                Console.WriteLine("No Quests Available");

            List<Quest> completed = GameStorage.Get().Player.Quests.Where(q => q.IsFinished).ToList();
            if (completed.Count > 0)
            {
                Console.WriteLine("\nCompleted Quests:");
                foreach (Quest q in completed)
                {
                    Console.WriteLine(q.Name);
                }
                Console.WriteLine("\n 'C' to turn in all Quests");
            }
        }
    }
}
