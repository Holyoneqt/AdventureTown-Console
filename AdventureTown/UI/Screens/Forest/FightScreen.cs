using AdventureTown.Data;
using AdventureTown.Models.Entities;
using AdventureTown.Models.Entities.Enemy;
using AdventureTown.Models.Gameplay.Attributes;
using AdventureTown.Models.Gameplay.Helpers;
using AdventureTown.Models.Gameplay.Quests;
using AdventureTown.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Screens.Forest
{
    public class FightScreen : IScreen
    {
        private Player _player;
        private DefaultForestEnemy _enemy;

        private AttackReport _playerReport;
        private AttackReport _enemyReport;

        public string HandleInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.A:
                    _playerReport = _player.Attack(_enemy);
                    _enemyReport = _enemy.Attack(_player);
                    break;
                default:
                    break;
            }
            return "";
        }

        public void OnClose()
        {
        }

        public void OnLoad()
        {
            _player = GameStorage.Get().Player;
            _enemy = new DefaultForestEnemy();

            _playerReport = null;
            _enemyReport = null;
        }

        public void Render()
        {
            Console.WriteLine($"{_player.Name}\n{CreateHealthBar(_player)}");
            Console.WriteLine($"\n{_enemy.Name}\n{CreateHealthBar(_enemy)}");

            if(_playerReport != null && _enemyReport != null)
            {
                if(_playerReport.IsCriticalDamage)
                    Console.WriteLine($"\nYou dealt {Math.Round(_playerReport.DamageDealt, 1)} Damage (CRITICAL) to {_playerReport.Target.Name}!");
                else
                    Console.WriteLine($"\nYou dealt {Math.Round(_playerReport.DamageDealt, 1)} Damage to {_playerReport.Target.Name}!");

                if(_enemyReport.IsCriticalDamage)
                    Console.WriteLine($"You received {Math.Round(_enemyReport.DamageDealt, 1)} Damage (CRITICAL) from {_enemyReport.DamageSource.Name}!");
                else
                    Console.WriteLine($"You received {Math.Round(_enemyReport.DamageDealt, 1)} Damage from {_enemyReport.DamageSource.Name}!");
            }

            Console.WriteLine("\nA = Attack, ...");
    
            if(_enemy.IsDead)
            {
                _player.OnKill(_enemy);
                _player.UpdateQuests(QuestStatus.EnemyKilled);

                Console.Clear();
                Console.WriteLine($"You killed {_enemy.Name}!");
                Console.WriteLine("You looted:");
                Console.WriteLine($" - {_enemy.GoldValue} Gold.");
                foreach (Item i in _enemy.Loot)
                {
                    Console.WriteLine($" - {i.Name}");
                }
                Console.WriteLine("\n'Q' to go deeper into the Forest...");
            }
        }

        private string CreateHealthBar(Entity entity)
        {
            EntityAttribute stamina = entity.Attributes.Get(AttributeType.Stamina);
            string healthBar = "|";
            int percent = (int) ((entity.CurrentHealth * 100) / entity.MaxHealth) / 10;
            for (int i = 0; i < 10; i++)
            {
                if (i < percent)
                    healthBar += "*";
                else
                    healthBar += " ";
            }
            healthBar += "|";
            return healthBar;
        }
    }
}
