using AdventureTown.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureTown.Models.Gameplay.Quests;
using AdventureTown.Data;

namespace AdventureTown.Models.Gameplay.Quests
{
    public class QuestObjective
    {
        public string Description { get; set; }
        public bool IsFinished { get; private set; }

        public int Required => _required;
        public int Current => _current;

        private int _current;
        private int _required;
        private QuestType _type;

        public QuestObjective(QuestType type)
        {
            IsFinished = false;
            _type = type;
            GenerateObjectives(type);
        }

        public void Progress()
        {
            if (_current < _required)
                _current += 1;

            if (_current >= _required)
                IsFinished = true;
        }

        private void GenerateObjectives(QuestType type)
        {
            switch (type)
            {
                case QuestType.Normal:
                    Description = "Kill some Enemies!";
                    _required = GameStorage.Random.Next(4, 10);
                    break;
                case QuestType.Dungeon:
                    Description = "Clear a Dungeon!";
                    _required = 1;
                    break;
                case QuestType.Heroic:
                    Description = "Not yet implemented!";
                    _required = 1;
                    break;
                case QuestType.Legendary:
                    Description = "Not yet implemented!";
                    _required = 1;
                    break;
                default:
                    break;
            }
            _current = 0;
        }
    }
}
