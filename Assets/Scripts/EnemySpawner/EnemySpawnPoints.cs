using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FightingSim
{
    [CreateAssetMenu(fileName = "Enemy Spawn Points", menuName = "Fight Sim/Spawn Points/Enemy")]
    public class EnemySpawnPoints : ScriptableObject
    {
        [SerializeField] private Transform _spawnPoints;

        public List<Transform> GetSpawnPoints => _spawnPoints.GetComponentsInChildren<Transform>().ToList();
    }
}
