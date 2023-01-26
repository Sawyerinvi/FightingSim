using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer
{
    public class WeaponInitializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly IWeaponConfig _config;
        private readonly Transform _transform;

        public WeaponInitializer(DiContainer container, IWeaponConfig config, Transform transform)
        {
            _container = container;
            _config = config;
            _transform = transform;
        }

        public void Initialize()
        {
            _transform.SetParent(_config.WeaponTransform, false);
            _container.InstantiatePrefab(_config.Prefab);
        }
    }
}
