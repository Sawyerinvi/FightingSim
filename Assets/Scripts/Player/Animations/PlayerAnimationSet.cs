using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Player.Animations
{
    public class PlayerAnimationSet
    {
        private readonly Animator _animator;

        private const string _attackAnimationName = "Attack Animation";
        private const string _idleAnimationName = "Player Idle";

        public readonly AnimationClip Attack;
        public readonly AnimationClip Idle;

        public PlayerAnimationSet(Animator animator)
        {
            _animator = animator;
            Attack = FindAnimation(_attackAnimationName);
            Idle = FindAnimation(_idleAnimationName);
        }
        private AnimationClip FindAnimation(string name)
        {
            foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name == name) return clip;
            }
            Debug.LogError("No animation found in Animator Controller with the name: " + name);
            return null;
        }
    }
}