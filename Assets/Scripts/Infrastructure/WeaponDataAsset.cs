using FightingSim.Assets.Scripts.System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Infrastructure
{
    [CreateAssetMenu(fileName = "Weapon Data Set", menuName = "Fight Sim/Weapon Data Set")]
    public class WeaponDataAsset : Config
    {
        [SerializeField] private List<WeaponData> _weaponData;
        

#if UNITY_EDITOR
        private void OnValidate()
        {
            var distinctList = _weaponData.Distinct().ToList();
            if(_weaponData.Count != distinctList.Count)
            {
                Debug.LogError("Added non-unic Weapon Asset in Weapon Data Asset");
            }
        }
        public List<IWeaponConfig> WeaponsData()
        {
            List<IWeaponConfig> list = new List<IWeaponConfig>();
            foreach (var data in _weaponData)
            {
                list.Add(data);
            }
            return list;
        } 
#endif
    }
}

