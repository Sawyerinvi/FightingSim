using FightingSim.Assets.Scripts.EnemySpawner.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace FightingSim.Assets.Scripts.EnemySpawner
{
    public class SpawnerContent
    {
        private List<EnemyFacade> _aliveEnemies;
        private Queue<EnemyFacade> _deadEnemies;

        public SpawnerContent()
        {
            _aliveEnemies = new List<EnemyFacade>();
            _deadEnemies = new Queue<EnemyFacade>();
        }
        public void AddNewEnemy(EnemyFacade enemy)
        {
            _aliveEnemies.Add(enemy);
            enemy.OnDeath += EnemyDeath;
        }

        private void EnemyDeath(EnemyFacade enemy)
        {
            if (_aliveEnemies.Contains(enemy))
            {
                _aliveEnemies.Remove(enemy);
            }
            else Debug.Log("No enemy in the list of alive enemy found");

            _deadEnemies.Enqueue(enemy);
            enemy.OnDeath -= EnemyDeath;
        }
    }
}
