using AdventureTown.Data;
using AdventureTown.Models.Entities.Enemy;
using AdventureTown.Models.Gameplay.Attributes;
using AdventureTown.Models.Gameplay.Quests;
using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Entities
{
    public class Player : Entity
    {
        private int _gold;
        public int Gold => _gold;

        public List<Quest> Quests { get; }
        public List<Item> Backpack { get; }

        private int _exp;
        public int Experience => _exp;
        public int Level { get; private set; }

        public int ExperienceToNextLevelUp { get { return CalculateExpToLevelUp(); } }

        public Player() : base()
        {
            Attributes.Set(AttributeType.Stamina, 10);
            Attributes.Set(AttributeType.Power, 10);
            Attributes.Set(AttributeType.Lethality, 5);
            Attributes.Set(AttributeType.Armor, 10);
            Quests = new List<Quest>();
            Backpack = new List<Item>();
            _gold = 10;
            Level = 1;
            _exp = 0;

            CurrentHealth = MaxHealth;
        }
        public void OnKill(EntityEnemy enemy)
        {
            Loot(enemy);
            IncreaseXp(10);
        }

        public void Loot(EntityEnemy toLoot)
        {
            AddGold(toLoot.GoldValue);
            foreach (Item i in toLoot.Loot)
            {
                Backpack.Add(i);
            }
        }

        public void UpdateQuests(QuestStatus status)
        {
            foreach (Quest q in Quests)
            {
                q.Update(status);
            }
        }

        public void TurnInQuest(Quest q)
        {
            Quests.Remove(q);
        }

        public void AddGold(int amount)
        {
            _gold += amount;
        }

        public void IncreaseXp(int amount)
        {
            if (_exp + amount < ExperienceToNextLevelUp)
                _exp += amount;
            else
            {
                int xpForNextLevel = (_exp + amount) - ExperienceToNextLevelUp;
                Level += 1;
                _exp = xpForNextLevel;
            }
        }

        private int CalculateExpToLevelUp()
        {
            return (int) (20 + ((Level / Constants.ExperieceConstant) * (Level / Constants.ExperieceConstant)));
        }

    }
}
