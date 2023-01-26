using FightingSim.Assets.Scripts.System;
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

        public TargetSelect PlayerTargets => _targetSelect;
        public PlayerWeaponInventory PlayerWeaponInventory => _weaponInventory;        

    }
}
