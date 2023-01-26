using FightingSim.Assets.Scripts.System;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Player
{

    public class TargetSelect
    {
        private List<ISelectable> _targetList = new List<ISelectable>();

        public event Action<List<ISelectable>> OnAddingTarget;

        public void SelectTarget(GameObject target)
        {
            if (target.TryGetComponent<ISelectable>(out var selectable))
            {
                selectable.GetSelected();
                _targetList.Add(selectable);
                OnAddingTarget(_targetList);
                selectable.OnDeath += (() => DeselectTarget(target));
            }

        }

        public void DeselectTarget(GameObject target)
        {
            if (target.TryGetComponent<ISelectable>(out var selectable))
            {
                selectable.GetDeselected();
                _targetList.Remove(selectable);
                OnAddingTarget(_targetList);
            }
        }
    }
}