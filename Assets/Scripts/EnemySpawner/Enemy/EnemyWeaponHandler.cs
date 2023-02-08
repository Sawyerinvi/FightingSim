using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyWeaponHandler : MonoBehaviour
    {
        private EnemyConfig _config;
        private Weapon.Factory _factory;
        [Inject]
        public void Construct(EnemyConfig config, Weapon.Factory facttory)
        {
            _config = config;
            _factory = facttory;
            

        }
        private void Awake()
        {
            WeaponData weaponData = _config.Weapon;
            weaponData.WeaponTransform = transform;
            Weapon weapon = _factory.Create(weaponData);
            weapon.IsPlayerDamagable = true;
        }
    }
}
