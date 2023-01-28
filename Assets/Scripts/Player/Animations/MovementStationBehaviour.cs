using FightingSim.Assets.Scripts.Player.Animations.States;
using System.Collections.Generic;
using System.Linq;

namespace FightingSim.Assets.Scripts.Player.Animations
{
    public class MovementStationBehaviour : IPlayerStateSwitcher
    {
        private readonly PlayerControl _control;
        private readonly AnimationController _animationController;
        private BaseState _currentState;
        private List<BaseState> _allStates;

        public MovementStationBehaviour(PlayerControl control, AnimationController animationController)
        {
            _control = control;
            _animationController = animationController;

            _allStates = new List<BaseState>
            {
                new AttackState(_control, this),
                new IdleState(_control, this),
                new MoveState(_control, this)
            };
            SwitchState<IdleState>();
        }
        public void AttackStart()
        {
            _currentState.AttackStart();
        }
        public void AttackEnd()
        {
            _currentState.AttackEnd();
        }
        public void Idle()
        {
            _currentState.Idle();
        }
        public void Move()
        {
            _currentState.Move();
        }
        public void SwitchState<T>() where T : BaseState
        {
            _currentState = _allStates.FirstOrDefault(s => s is T);
        }
    }
}
