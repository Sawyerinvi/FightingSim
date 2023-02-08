using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Weapons;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using System;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    public class CurrentStats : IInitializable
    {
        private readonly PlayerConfig _config;
        private float _maxHealth;
        private float _currentHealth;
        public float CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;
        public event Action OnHealthChanged;

        public CurrentStats(ConfigManager config)
        {
            _config = config.GetConfig<PlayerConfig>();
        }
        public void Initialize()
        {
            _maxHealth = _config.Health;
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke();
        }
        public void TakeDamage(Damage damage)
        {
            float combinedDamage = 0;
            foreach (var amount in damage.CollectedDamage)
            {
                combinedDamage += amount.Value;
            }
            _currentHealth -= combinedDamage;
            OnHealthChanged?.Invoke();
        }
    }
}
