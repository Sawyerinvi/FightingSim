using FightingSim.Assets.Scripts.EnemySpawner.Enemy;
using FightingSim.Assets.Scripts.Infrastructure;
using FightingSim.Assets.Scripts.Player;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner
{
    public class Spawner : IInitializable
    {
        private readonly EnemyFacade.Factory _factory;
        private readonly SpawnerContent _spawnerContent;
        private readonly EnemySpawnPoints _spawnPoints;
        private readonly AsyncProcessor _processor;

        private float _playerCheckOverlapRadius = 2f;
        private int _timer = 5;
        private int _enemyAmount = 10;

        public Spawner(EnemyFacade.Factory factory, SpawnerContent spawnerContent, EnemySpawnPoints spawnPoints, AsyncProcessor processor)
        {
            _factory = factory;
            _spawnerContent = spawnerContent;
            _spawnPoints = spawnPoints;
            _processor = processor;
        }

        public void Initialize()
        {
            _processor.StartCoroutine(SpawnCountdown());
        }

        private IEnumerator SpawnCountdown()
        {
            for (int i = 0; i < _enemyAmount; i++)
            {
                yield return new WaitForSeconds(_timer);
                Transform point;

                for (int j = 0; j < 100; j++)
                {
                    point = _spawnPoints.GetSpawnPoints[Random.Range(0, _spawnPoints.GetSpawnPoints.Count)];
                    if (CheckForPlayer(point.position) == false)
                    {
                        SpawnEnemyAtPoint(point.position);
                        break;
                    }
                }
                yield return null;
            }
        }

        private void SpawnEnemyAtPoint(Vector3 point)
        {
            EnemyFacade enemy = _factory.Create();
            enemy.SetPosition(point);
            _spawnerContent.AddNewEnemy(enemy);
        }

        private bool CheckForPlayer(Vector3 origin)
        {
            Collider[] hits = Physics.OverlapSphere(origin,  _playerCheckOverlapRadius);
            foreach (var hit in hits)
            {
                if (hit.gameObject.TryGetComponent<PlayerComponent>(out var _))
                {
                    return true;
                }
                    
            } return false;
        }
    }

}
