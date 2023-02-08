using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    class PlayerMovement : MonoBehaviour
    {
        private Camera _camera;
        private PlayerConfig _config;
        private PlayerControl _control;
        private InputHandler _inputHandler;
        private float _speed;
        [Inject]
        public void Construct(Camera camera, ConfigManager config, PlayerControl control, InputHandler inputHandler)
        {
            _camera = camera;
            _control = control;
            _config = config.GetConfig<PlayerConfig>();
            _inputHandler = inputHandler;

            _control.OnMoveAction += Move;
            _speed = _config.MovementSpeed;
        }
        
        private void Move()
        {
            transform.position += new Vector3(_inputHandler.Horizontal, 0, _inputHandler.Vertical).
                normalized * Time.deltaTime * _speed;

            Vector3 mousePosition = _inputHandler.MousePosition;
            mousePosition.z = _camera.nearClipPlane + 12;
            Vector3 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
            transform.LookAt(new Vector3(worldPosition.x, transform.position.y, worldPosition.z));
        }
        private void OnDestroy()
        {
            _control.OnMoveAction -= Move;
        }
    }
}
