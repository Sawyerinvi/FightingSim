using FightingSim.Assets.Scripts.Player.Animations;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    public class InputHandler : ITickable, IFixedTickable
    {
        private readonly MovementStationBehaviour _stationBehaviour;
        private PlayerControl _control;
        private Vector3 _previousMousePosition;
        
        public InputHandler(MovementStationBehaviour stationBehaviour, PlayerControl control)
        {
            _stationBehaviour = stationBehaviour;
            _control = control;
        }

        public void FixedTick()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var mousePosition = Input.mousePosition;

            _control.Horizontal = horizontal;
            _control.Vertical = vertical;
            _control.MousePosition = mousePosition;

            if (horizontal != 0 || vertical != 0 || mousePosition != _previousMousePosition)
            {
                _previousMousePosition = mousePosition;
                _stationBehaviour.Move();
            }
            else
            {
                _stationBehaviour.Idle();
            }
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _stationBehaviour.AttackStart();
            }
        }
    }
}
