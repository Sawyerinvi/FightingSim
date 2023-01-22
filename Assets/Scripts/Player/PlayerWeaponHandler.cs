using Zenject;
using UnityEngine;
using FightingSim.Assets.Scripts.Player.Animations;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;

namespace FightingSim.Assets.Scripts.Player
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        private PlayerControl _playerControl;
        private AnimationController _animationController;
        private PlayerWeaponInventory _weaponInventory;

        [Inject]
        public void Construct(AnimationController animationController, PlayerControl playerControl, PlayerWeaponInventory weaponInventory)
        {
            _weaponInventory = weaponInventory;
            weaponInventory.WeaponHandlerTransform = transform;
            _animationController = animationController;
            _playerControl = playerControl;

            _playerControl.OnAttackStart += PerformAttack;
            _playerControl.OnAttackEnd += AttackCallback;
        }
        private void PerformAttack()
        {            
            _weaponInventory.GetActiveWeapon.SetActive(true);
            _animationController.Attack(AttackCallback);
        }

        private void AttackCallback()
        {
            _weaponInventory.GetActiveWeapon.SetActive(false);
        }
        private void OnDestroy()
        {
            _playerControl.OnAttackStart -= PerformAttack;
            _playerControl.OnAttackEnd -= AttackCallback;
        }
    }
}