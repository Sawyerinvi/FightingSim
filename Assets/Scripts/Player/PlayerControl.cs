using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Player.Animations;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    public class PlayerControl
    {
        private readonly Camera _camera;
        private readonly PlayerAnimationController _animationController;
        private readonly PlayerWeaponInventory _weaponInventory;

        public event Action OnAttackStart;
        public event Action OnAttackEnd;
        public event Action OnMoveAction;

        public PlayerControl(PlayerAnimationController animationController, PlayerWeaponInventory weaponInventory)
        {
            _animationController = animationController;
            _weaponInventory = weaponInventory;
        }

        public void Move()
        {
            OnMoveAction?.Invoke();
        }

        public void AttackStart(Action callback)
        {
            if (_weaponInventory.GetActiveWeapon == null)
            {
                callback();
                return;
            }
            _animationController.Attack(callback);
            OnAttackStart?.Invoke();
        }
        public void AttackEnd()
        {
            OnAttackEnd?.Invoke();
        }
    }
}
