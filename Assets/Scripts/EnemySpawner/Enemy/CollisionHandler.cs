using FightingSim.Assets.Scripts.Infrastructure;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using System;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class CollisionHandler : MonoBehaviour
    {
        private CurrentStats _currentStats;
        [Inject]
        public void Construct(CurrentStats currentStats)
        {
            _currentStats = currentStats;
            
        }

        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<ICollisionFacade<Weapon>>(out var weaponColliderFacade))
            {
                Weapon weapon = weaponColliderFacade.GetFacade();
                if(weapon.IsEnemyDamagable) _currentStats.TakeDamage(weapon);

            }
        }
    }
}