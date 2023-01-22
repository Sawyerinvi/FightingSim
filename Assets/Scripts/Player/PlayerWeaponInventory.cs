using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingSim.Assets.Scripts.System;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using System.Linq;

namespace FightingSim.Assets.Scripts.Player
{
    public class PlayerWeaponInventory
    {
        private WeaponFactory _factory;
        private List<Weapon> _availableWeapons = new List<Weapon>();
        private Weapon _activWeapon;

        public Weapon GetActiveWeapon => _activWeapon;
        public List<Weapon> GetAvailableWeapons => _availableWeapons;
        public Transform WeaponHandlerTransform { get; set; }
        public PlayerWeaponInventory(WeaponFactory factory)
        {
            _factory = factory;
        }
        
        public void AddWeapon(IWeaponConfig weaponConfig)
        {
            if (IsExisting(weaponConfig.WeaponName) == false)
            {
                var newWeapon = _factory.Create(weaponConfig, WeaponHandlerTransform);
                _availableWeapons.Add(newWeapon);
                newWeapon.SetActive(false);
                SetActiveWeapon(newWeapon);
            }
        }
        public void ChangeWeapon(string name)
        {
            var weaponDic = WeaponByName();
            if(weaponDic.ContainsKey(name))
            {
                SetActiveWeapon(weaponDic[name]);
            }
            
        }
        private void SetActiveWeapon(Weapon weapon)
        {
            if (_availableWeapons.Contains(weapon))
            {
                foreach (Weapon obj in _availableWeapons)
                {
                    obj.SetActive(false);
                }
                _activWeapon = weapon;
            }
        }
        private bool IsExisting(string name)
        {
            foreach (var weapon in _availableWeapons)
            {
                if (weapon.WeaponName.Equals(name)) return true;
            }
            return false;
        }
        private Dictionary<string, Weapon> WeaponByName()
        {
            Dictionary<string, Weapon> weaponByName = _availableWeapons.ToDictionary(x => x.WeaponName, x => x);
            return weaponByName;
        }
        
    }
}