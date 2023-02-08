using FightingSim.Assets.Scripts.Infrastructure;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    class PlayerCollisionFacade : MonoBehaviour, ICollisionFacade<PlayerFacade>
    {
        private PlayerFacade _player;
        private CurrentStats _currentStats;
        [Inject]
        public void Construct(PlayerFacade player, CurrentStats currentStats)
        {
            _player = player;
            _currentStats = currentStats;
        }
        public PlayerFacade GetFacade()
        {
            return _player;
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<ICollisionFacade<Weapon>>(out var weaponColliderFacade))
            {
                Weapon weapon = weaponColliderFacade.GetFacade();
                if (weapon.IsPlayerDamagable) _currentStats.TakeDamage(weapon.DealDamage());

            }
        }
    }
}
