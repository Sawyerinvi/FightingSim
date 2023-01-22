using System;

namespace FightingSim.Assets.Scripts.Player.Animations.States
{
    public abstract class BaseState
    {
        protected readonly PlayerControl _control;
        protected readonly IPlayerStateSwitcher _stateSwitcher;
        protected readonly AnimationController _animationController;

        protected BaseState(PlayerControl control, IPlayerStateSwitcher stateSwitcher)
        {
            _control = control;
            _stateSwitcher = stateSwitcher;
        }

        public abstract void AttackStart();
        public abstract void AttackEnd();
        public abstract void Move();
        public abstract void Idle();
    }
}