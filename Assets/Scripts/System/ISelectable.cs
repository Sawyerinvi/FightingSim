using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingSim.Assets.Scripts.System
{
    public interface ISelectable
    {
        public event Action<GameObject> OnDeath;
        public void GetSelected();

        public void GetDeselected();

        public string Name { get; }

    }
}