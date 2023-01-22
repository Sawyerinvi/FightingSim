using FightingSim.Assets.Scripts.System;
using UnityEngine;
using Zenject;


namespace FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer
{
    public class WeaponFactory
    {
        private readonly DiContainer _container;

        public WeaponFactory(DiContainer container)
        {
            _container = container;
        }

        public Weapon Create(IWeaponConfig config, Transform transform)
        {
            DiContainer sub1 = _container.CreateSubContainer();
            sub1.Bind<IWeaponConfig>().FromInstance(config);
            GameObject obj = sub1.InstantiatePrefab(config.Prefab, transform);
            float offset = obj.GetComponent<Renderer>().bounds.size.z / 2;
            obj.transform.localPosition = new Vector3(0, 0, offset);
            sub1.Bind<Transform>().FromInstance(obj.transform).AsSingle();
            sub1.BindInterfacesAndSelfTo<Weapon>().AsSingle();

            return sub1.Resolve<Weapon>();
        }
    }
}
