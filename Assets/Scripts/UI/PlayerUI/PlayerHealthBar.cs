using FightingSim.Assets.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FightingSim.Assets.Scripts.UI.PlayerUI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _foreground;
        [SerializeField] private TMP_Text _healthText; 
        private CurrentStats _currentStats;
        private PlayerFacade _player;

        [Inject]
        public void Construct(PlayerFacade player)
        {
            _player = player;
        }
        private void Awake()
        {
            _currentStats = _player.CurrentStats;
            _currentStats.OnHealthChanged += UpdateHealth;
            UpdateHealth();
        }
        private void UpdateHealth()
        {
            _foreground.fillAmount = _currentStats.CurrentHealth / _currentStats.MaxHealth;
            _healthText.text = $"{_currentStats.CurrentHealth}/{_currentStats.MaxHealth}";
        }
    }
}
