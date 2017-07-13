using AdventureTown.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Gameplay.Quests
{
    public class Quest
    {
        private string[] _names = new string[] { "Slaughter of the Chickens", "Up up and away", "Au revoir", "Hakuna Matata", "How many children is that now?","Whatchamacallit" };

        public string Name { get; }
        public QuestType Type { get; }
        public QuestObjective Objective { get; }

        public bool IsFinished { get { return Objective.IsFinished; } }

        public Quest(QuestType diff)
        {
            Name = _names[GameStorage.Random.Next(_names.Length)];
            Type = diff;
            Objective = new QuestObjective(Type);
        }

        public void Update(QuestStatus status)
        {
            switch (status)
            {
                case QuestStatus.EnemyKilled:
                    if (Type == QuestType.Normal)
                        Objective.Progress();
                    break;
                case QuestStatus.DungeonCleared:
                    if (Type == QuestType.Dungeon)
                        Objective.Progress();
                    break;
                default:
                    break;
            }
        }
    }
}
