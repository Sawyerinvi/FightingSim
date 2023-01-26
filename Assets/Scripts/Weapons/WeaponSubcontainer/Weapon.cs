using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Player;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer
{
    public class Weapon
    {
        private Transform _transform;
        private string _name;
        private IWeaponConfig _weaponData;

        public string WeaponName => _name;

        public Weapon(IWeaponConfig data, Transform transform)
        {
            _weaponData = data;
            _transform = transform;
            WeaponSetup();
        }
        
        public Damage DealDamage()
        {
            var dmg = _weaponData.GetWeaponBaseDamage();
            return dmg;
        }
        public void SetActive(bool state)
        {
            _transform.gameObject.SetActive(state);
        }
        private void WeaponSetup()
        {
            _name = _weaponData.WeaponName;
        }


        public class Factory : PlaceholderFactory<IWeaponConfig, Weapon>
        {

        }
    }
}