using System.Collections;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Player.Animations.States
{
    public class IdleState : BaseState
    {
        public IdleState(PlayerControl control, IPlayerStateSwitcher stateSwitcher) : base(control, stateSwitcher)
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
            
        }

        public override void Move()
        {
            _stateSwitcher.SwitchState<MoveState>();
            _control.Move();
        }


    }
}