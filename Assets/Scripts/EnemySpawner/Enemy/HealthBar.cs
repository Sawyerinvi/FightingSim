using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarImage;
        [SerializeField] private TMP_Text _healthText;

        private CurrentStats _stats;

        [Inject]
        public void Construct(CurrentStats stats)
        {
            _stats = stats;

            _stats.OnHealthChanged += HealthDisplay;

        }

        private void Awake()
        {
            HealthDisplay();
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }

        private void HealthDisplay()
        {
            var healthPct = _stats.CurrentHealth / _stats.MaxHealth;
            _healthBarImage.fillAmount = healthPct;
            _healthText.text = _stats.CurrentHealth.ToString();
        }

        private void OnDestroy()
        {
            _stats.OnHealthChanged -= HealthDisplay;
        }
    }
}