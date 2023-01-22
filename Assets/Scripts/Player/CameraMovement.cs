using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    public class CameraMovement : ILateTickable
    {
        private readonly Transform _transform;
        private readonly Transform _cameraTransform;

        private Vector3 _offset = new Vector3(0, 10, -4);

        public CameraMovement(Transform transform, Camera camera)
        {
            _transform = transform;
            _cameraTransform = camera.transform;
        }

        public void LateTick()
        {
            _cameraTransform.position = _transform.position + _offset;
            _cameraTransform.LookAt(_transform);
        }


    }
}
