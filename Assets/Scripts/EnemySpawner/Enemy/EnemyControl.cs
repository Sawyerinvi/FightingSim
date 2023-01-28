using FightingSim.Assets.Scripts.Player;
using UnityEngine.AI;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyControl
    {
        private readonly PlayerFacade _player;
        private readonly NavMeshAgent _navAgent;

        public EnemyControl(PlayerFacade player, NavMeshAgent navAgent)
        {
            _player = player;
            _navAgent = navAgent;
        }

        public void MoveToPlayer()
        {

        }
        public void Idle()
        {

        }
        public void Attack()
        {

        }
    }
}
