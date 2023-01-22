using FightingSim.Assets.Scripts.Weapons;
using System;
using UnityEngine;

namespace FightingSim.Assets.Scripts.System
{
    public interface IWeaponConfig
    {
        public GameObject Prefab { get; }
        public string WeaponName { get; }
        public Damage GetWeaponBaseDamage();
    }
}
