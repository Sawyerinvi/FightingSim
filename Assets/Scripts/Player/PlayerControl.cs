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
        public float Horizontal { get; set; }
        public float Vertical { get; set; }
        public Vector3 MousePosition { get; set; }
        public bool HasWeapon { get; set; }

        private readonly PlayerConfig _config;
        private readonly Transform _transform;
        private readonly Camera _camera;
        private readonly PlayerAnimationController _animationController;
        PlayerWeaponInventory _weaponInventory;
        private float _speed;

        public event Action OnAttackStart;
        public event Action OnAttackEnd;


        public PlayerControl(ConfigManager config, Transform transform, Camera camera, PlayerAnimationController animationController, PlayerWeaponInventory weaponInventory)
        {
            _config = config.GetConfig<PlayerConfig>();
            _transform = transform;
            _camera = camera;
            _animationController = animationController;
            _weaponInventory = weaponInventory;

            _speed = _config.MovementSpeed;
        }        

        public void Move()
        {
            _transform.position += new Vector3(Horizontal, 0, Vertical).
                normalized * Time.deltaTime * _speed;

            Vector3 mousePosition = MousePosition;
            mousePosition.z = _camera.nearClipPlane + 12;
            Vector3 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
            _transform.LookAt(new Vector3(worldPosition.x, _transform.position.y, worldPosition.z));
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
