using FightingSim.Assets.Scripts.Infrastructure;
using FightingSim.Assets.Scripts.Weapons;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public partial class CurrentStats : IInitializable
    {
        private readonly EnemyConfig _config;

        private IDictionary<DamageType, float> _damageResistances = new Dictionary<DamageType, float>();

        private float _maxHealth;
        private float _currenthealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currenthealth;

        public event Action OnHealthChanged;
        public event Action OnDeath;

        public CurrentStats(ConfigManager config)
        {
            _config = config.GetConfig<EnemyConfig>();
        }

        public void AddSourceOfResistance(DamageResistances resistance)
        {

        }
        public void Initialize()
        {
            _maxHealth = _config.MaxHealth;
            _currenthealth = _maxHealth;
        }
        public void TakeDamage(Weapon weapon)
        {
            _currenthealth -= CalculateDefenses(weapon.DealDamage());
            OnHealthChanged?.Invoke();
            if (_currenthealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }
        private float CalculateDefenses(Damage incomingDmg)
        {
            float totalDmg = 0;
            foreach (var dmg in incomingDmg.CollectedDamage)
            {
                totalDmg += dmg.Value;
            }
            return totalDmg;
        }
    }
}