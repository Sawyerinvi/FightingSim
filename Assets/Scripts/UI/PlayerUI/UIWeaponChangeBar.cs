using FightingSim.Assets.Scripts.Player;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FightingSim.Assets.Scripts.UI.PlayerUI
{
    public class UIWeaponChangeBar : MonoBehaviour
    {
        [SerializeField] private Button _changeWeaponButton;
        [SerializeField] private TMP_Dropdown _weaponOptionDropdown;

        private PlayerWeaponInventory _weaponInventory;

        [Inject]
        public void Construct(PlayerFacade player)
        {
            _weaponInventory = player.PlayerWeaponInventory;
        }
        private void Awake()
        {
            _weaponOptionDropdown.gameObject.SetActive(false);
            _changeWeaponButton.onClick.AddListener(ChangeWeapon);
        }
        private void ChangeWeapon()
        {
            if (_weaponOptionDropdown.IsActive())
            {
                if (_weaponOptionDropdown.options.Any())
                {
                    string name = _weaponOptionDropdown.options[_weaponOptionDropdown.value].text;
                    _weaponInventory.ChangeWeapon(name);
                }
                _weaponOptionDropdown.gameObject.SetActive(false);
                
            }
            else
            {
                ShowAllWeapon();
            }
        }
        private void ShowAllWeapon()
        {
            _weaponOptionDropdown.gameObject.SetActive(true);
            _weaponOptionDropdown.options.Clear();
            foreach (var weapon in _weaponInventory.GetAvailableWeapons)
            {
                var newOption = new TMP_Dropdown.OptionData();
                newOption.text = weapon.WeaponName;
                _weaponOptionDropdown.options.Add(newOption);
                _weaponOptionDropdown.RefreshShownValue();
            }
        }
    }
}