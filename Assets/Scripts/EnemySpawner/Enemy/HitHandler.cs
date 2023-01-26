using FightingSim.Assets.Scripts.System;
using System;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class HitHandler : MonoBehaviour, ISelectable
    {
        private Renderer _renderer;
        private Color _initialColor;
        private CurrentStats _currentStats;

        private string _name;

        public string Name => _name;
        public event Action OnDeath;

        [Inject]
        public void Construct(string name, CurrentStats currentStats)
        {
            _name = name;
            _currentStats = currentStats;
            _currentStats.OnDeath += DeathHandler;
        }
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }
        private void DeathHandler()
        {
            OnDeath?.Invoke();
        }

        public void GetSelected()
        {
            if (_initialColor != _renderer.material.color) _initialColor = _renderer.material.color;
            _renderer.material.color = Color.yellow;
        }
        public void GetDeselected()
        {
            if (_initialColor == null) return;
            _renderer.material.color = _initialColor;
            _currentStats.OnDeath -= DeathHandler;
        }

    }
}