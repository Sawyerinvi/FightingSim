using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Player
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Fight Sim/Config/Player")]
    public class PlayerConfig : Config
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _targetDetectionRadius;

        public float MovementSpeed => _movementSpeed;
        public float TargetDetectionRadius => _targetDetectionRadius;
        
    }
}
