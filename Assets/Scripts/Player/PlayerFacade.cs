using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    public class PlayerFacade
    {
        [Inject]
        private TargetSelect _targetSelect;
        [Inject]
        private PlayerWeaponInventory _weaponInventory;
        [Inject]
        private Transform _transform;
        [Inject]
        private CurrentStats _currentStats;

        public TargetSelect PlayerTargets => _targetSelect;
        public PlayerWeaponInventory PlayerWeaponInventory => _weaponInventory;
        public Vector3 PlayerPosition => _transform.position;
        public CurrentStats CurrentStats => _currentStats;
    }
}
