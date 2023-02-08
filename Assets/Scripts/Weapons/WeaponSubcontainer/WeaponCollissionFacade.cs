using FightingSim.Assets.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer
{
    public class WeaponCollissionFacade : MonoBehaviour, ICollisionFacade<Weapon>
    {
        private Weapon _weapon;

        [Inject]
        public void Construct(Weapon weapon)
        {
            _weapon = weapon;
        }

        public Weapon GetFacade()
        {
            return _weapon;
        }
    }

}
