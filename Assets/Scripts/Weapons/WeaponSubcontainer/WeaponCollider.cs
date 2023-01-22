using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer
{
    public class WeaponCollider : MonoBehaviour
    {
        private LazyInject<Weapon> _weapon;

        public Weapon Weapon => _weapon.Value;

        [Inject]
        public void Construct(LazyInject<Weapon> weapon)
        {
            _weapon = weapon;
        }

    }
}
