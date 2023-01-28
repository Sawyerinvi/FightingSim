using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations
{
    public class AnimationController
    {
        private readonly Animator _animator;

        public AnimationController(Animator animator)
        {
            _animator = animator;
        }
    }
}
