using UnityEngine;

namespace FightingSim.Assets.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Fight Sim/Config/Player")]
    public class PlayerConfig : Config
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _targetDetectionRadius;
        [SerializeField] private float _health;

        public float MovementSpeed => _movementSpeed;
        public float TargetDetectionRadius => _targetDetectionRadius;
        public float Health => _health;

    }
}
