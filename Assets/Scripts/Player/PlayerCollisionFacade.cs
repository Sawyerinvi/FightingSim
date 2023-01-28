using FightingSim.Assets.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    class PlayerCollisionFacade : MonoBehaviour, ICollisionFacade<PlayerFacade>
    {
        private PlayerFacade _player;
        [Inject]
        public void Construct(PlayerFacade player)
        {
            _player = player;
        }
        public PlayerFacade GetFacade()
        {
            return _player;
        }
    }
}
