using FightingSim.Assets.Scripts.Player;
using System.Collections;
using System;
using UnityEngine;
using Zenject;
using FightingSim.Assets.Scripts.Infrastructure;

namespace FightingSim.Assets.Scripts.Player.Animations
{
    public class AnimationController
    {
        private Animator _animator;
        private PlayerAnimationSet _animationSet;
        private AsyncProcessor _processor;


        public AnimationController(Animator animator, PlayerAnimationSet animationSet, AsyncProcessor processor)
        {
            _animator = animator;
            _animationSet = animationSet;
            _processor = processor;
        }
        public void Attack(Action onEndCallback)
        {
            _processor.StartCoroutine(AttackAnimation(onEndCallback));
        }
        private IEnumerator AttackAnimation(Action callback)
        {
            _animator.Play(_animationSet.Attack.name);
            yield return new WaitForSeconds(_animationSet.Attack.length);
            _animator.Play(_animationSet.Idle.name);
            callback();
        }

    }
}