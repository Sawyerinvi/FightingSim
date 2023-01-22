using System.Collections;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Player.Animations.States
{
    public class MoveState : BaseState
    {
        public MoveState(PlayerControl control, IPlayerStateSwitcher stateSwitcher) : base(control, stateSwitcher)
        {
        }


        public override void AttackStart()
        {
            _stateSwitcher.SwitchState<AttackState>();
            _control.AttackStart(AttackEnd);
        }
        public override void AttackEnd()
        {
            _stateSwitcher.SwitchState<IdleState>();
        }

        public override void Idle()
        {
            _stateSwitcher.SwitchState<IdleState>();
        }

        public override void Move()
        {
            _control.Move();
        }
    }
}