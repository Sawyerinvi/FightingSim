using UnityEngine;

namespace FightingSim.Assets.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(fileName = "Enemy Config", menuName = "Fight Sim/Config/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private GameObject _prefab;

        public float MaxHealth => _maxHealth;
        public GameObject Prefab => _prefab;
    }

}