using FightingSim.Assets.Scripts.Infrastructure;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using System;
using System.Collections;
using UnityEngine;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations
{
    public class EnemyAnimationController
    {
        private readonly Animator _animator;
        private readonly AsyncProcessor _processor;
        private readonly EnemyConfig _config;

        public EnemyAnimationController(Animator animator, AsyncProcessor processor, EnemyConfig config)
        {
            _animator = animator;
            _processor = processor;
            _config = config;

            _animator.runtimeAnimatorController = _config.AnimatorController;
        }
        public void Attack(Action onEndCallback)
        {
            _processor.StartCoroutine(AttackAnimation(onEndCallback));
        }
        private IEnumerator AttackAnimation(Action callback)
        {
            _animator.Play(EnemyAnimationSet.Attack);
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
            _animator.Play(EnemyAnimationSet.Idle);
            callback();
        }
    }
}
