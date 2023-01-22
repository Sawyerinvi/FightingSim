using FightingSim.Assets.Scripts.Player.Animations.States;
using System.Collections;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Player.Animations
{
    public interface IPlayerStateSwitcher
    {
        public void SwitchState<T>() where T : BaseState;
    }
}