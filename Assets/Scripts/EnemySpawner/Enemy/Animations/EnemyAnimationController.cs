using FightingSim.Assets.Scripts.Infrastructure;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations
{
    public class EnemyAnimationController : IInitializable
    {
        private Animator _animator;
        private readonly AsyncProcessor _processor;
        private readonly Transform _transform;

        public EnemyAnimationController(AsyncProcessor processor, Transform transform)
        {
            _processor = processor;
            _transform = transform;
        }
        public void Initialize()
        {
            _animator = _transform.GetComponentInChildren<Animator>();
        }
        public void Attack(Action onEndCallback)
        {
            _processor.StartCoroutine(AttackAnimation(onEndCallback));
        }
        private IEnumerator AttackAnimation(Action callback)
        {
            if(_animator != null)
            {
                _animator.Play(EnemyAnimationSet.Attack);
                yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
            }
            if (_animator != null) _animator.Play(EnemyAnimationSet.Idle);
            callback();
        }
    }
}
