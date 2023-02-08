using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : EnemyBaseState;
    }
}
