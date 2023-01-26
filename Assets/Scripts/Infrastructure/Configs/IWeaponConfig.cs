using FightingSim.Assets.Scripts.Weapons;
using System;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Infrastructure.Configs
{
    public interface IWeaponConfig
    {
        public GameObject Prefab { get; }
        public string WeaponName { get; }
        public Transform WeaponTransform { get; set; }
        public Damage GetWeaponBaseDamage();

    }
}
