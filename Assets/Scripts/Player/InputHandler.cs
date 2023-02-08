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

        private float _horizontal;
        private float _vertical;
        private Vector3 _mousePosition;
        public Vector3 MousePosition { get => _mousePosition; private set => _mousePosition = value; }
        public float Vertical { get => _vertical; private set => _vertical = value; }
        public float Horizontal { get => _horizontal; private set => _horizontal = value; }

        public InputHandler(MovementStationBehaviour stationBehaviour, PlayerControl control)
        {
            _stationBehaviour = stationBehaviour;
            _control = control;
        }

        public void FixedTick()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _mousePosition = Input.mousePosition;


            if (Horizontal != 0 || _vertical != 0 || _mousePosition != _previousMousePosition)
            {
                _previousMousePosition = _mousePosition;
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
