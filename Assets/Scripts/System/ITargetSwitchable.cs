using System.Collections.Generic;
using System;

namespace FightingSim.Assets.Scripts.System
{
    public interface ITargetSwitchable
    {
        public event Action<List<ISelectable>> OnAddingTarget;
    }
}