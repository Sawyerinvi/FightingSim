using UnityEngine;
using UnityEngine.AI;

namespace FightingSim.Assets.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(fileName = "Enemy Config", menuName = "Fight Sim/Config/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private RuntimeAnimatorController _animatorController;
        [SerializeField] private float _sphereSearchTimer;
        [SerializeField] private float _sphereSearchRadius;
        [SerializeField] private float _attackDistance;
        [SerializeField] private WeaponData _weapon;
        [SerializeField] private float _attackAngle;

        public float MaxHealth => _maxHealth;
        public GameObject Prefab => _prefab;
        public RuntimeAnimatorController AnimatorController => _animatorController;
        public float OverlapshpereTime => _sphereSearchTimer;
        public float SphereSearchRadius => _sphereSearchRadius;
        public float AttackDistance => _attackDistance;
        public WeaponData Weapon => _weapon;
        public float AttackAngle => _attackAngle;
    }
}