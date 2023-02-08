using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;


namespace FightingSim.Assets.Scripts.Weapons
{
    public class Damage
    {
        private IDictionary<DamageType, float> _collectedDmg = new Dictionary<DamageType, float>();
        public IReadOnlyDictionary<DamageType, float> CollectedDamage;

        public Damage()
        {
            foreach (DamageType type in (DamageType[])Enum.GetValues(typeof(DamageType)))
            {
                _collectedDmg.Add(type, 0);
            }
            CollectedDamage = new ReadOnlyDictionary<DamageType, float>(_collectedDmg);
        }

        public void AddDamage(DamageType type, float amount)
        {
            if (amount < 0f) return;
            if (_collectedDmg.ContainsKey(type)) _collectedDmg[type] += amount;
        }
    }
}