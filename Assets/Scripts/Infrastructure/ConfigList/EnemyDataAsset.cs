using FightingSim.Assets.Scripts.Infrastructure.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Infrastructure.ConfigList
{
    [CreateAssetMenu(fileName = "Enemy Data Set", menuName = "Fight Sim/Enemy Data Set")]
    public class EnemyDataAsset : Config
    {
        [SerializeField] private List<EnemyConfig> _enemyConfig;
        
        public List<EnemyConfig> GetEnemyConfigs()
        {
            return _enemyConfig;
        }
    }
}
