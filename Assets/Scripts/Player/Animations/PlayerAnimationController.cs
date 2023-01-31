using FightingSim.Assets.Scripts.Player;
using System.Collections;
using System;
using UnityEngine;
using Zenject;
using FightingSim.Assets.Scripts.Infrastructure;

namespace FightingSim.Assets.Scripts.Player.Animations
{
    public class PlayerAnimationController
    {
        private Animator _animator;
        private AsyncProcessor _processor;
        private readonly PlayerAnimationSet _playerAnimationSet;

        public PlayerAnimationController(Animator animator, AsyncProcessor processor, PlayerAnimationSet playerAnimationSet)
        {
            _animator = animator;
            _processor = processor;
            _playerAnimationSet = playerAnimationSet;
        }
        public void Attack(Action onEndCallback)
        {
            _processor.StartCoroutine(AttackAnimation(onEndCallback));
        }
        private IEnumerator AttackAnimation(Action callback)
        {
            _animator.Play(_playerAnimationSet.Attack.name);
            yield return new WaitForSeconds(_playerAnimationSet.Attack.length);
            _animator.Play(_playerAnimationSet.Idle.name);
            callback();
        }

    }
}