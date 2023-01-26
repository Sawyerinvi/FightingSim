using UnityEngine.UI;
using UnityEngine;
using FightingSim.Assets.Scripts.Player;
using System.Collections.Generic;
using TMPro;
using Zenject;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Infrastructure.ConfigList;

namespace FightingSim.Assets.Scripts.UI.PlayerUI
{
    public class UIAddWeaponBar : MonoBehaviour
    {
        [SerializeField] private Button _addWeaponButton;

        [SerializeField] private TMP_Dropdown _allWeaponsDropdown;

        private PlayerWeaponInventory _playerWeaponInventory;
        private WeaponDataAsset _weaponAsset;

        private Dictionary<string, IWeaponConfig> _configByName = new Dictionary<string, IWeaponConfig>();
        private List<IWeaponConfig> _weaponList;

        [Inject]
        public void Construct(PlayerFacade player, ConfigManager configManager)
        {
            _playerWeaponInventory = player.PlayerWeaponInventory;
            _weaponAsset = configManager.GetConfig<WeaponDataAsset>();
        }
        private void Awake()
        {
            _weaponList = _weaponAsset.GetWeaponsData();
            foreach (var weapon in _weaponList)
            {
                _configByName.Add(weapon.WeaponName, weapon);
            }

            ShowAllWeapons();
            _allWeaponsDropdown.gameObject.SetActive(false);
            _addWeaponButton.onClick.AddListener(AddWeapon);
            
        }
        private void AddWeapon()
        {
            if (_allWeaponsDropdown.gameObject.activeSelf)
            {
                string name = _allWeaponsDropdown.options[_allWeaponsDropdown.value].text;
                _playerWeaponInventory.AddWeapon(_configByName[name]);
                _allWeaponsDropdown.gameObject.SetActive(false);
            }
            else
            {
                _allWeaponsDropdown.gameObject.SetActive(true);
            }
        }
        
        
        private void ShowAllWeapons()
        {
            foreach (var weapon in _weaponList)
            {
                var newOption = new TMP_Dropdown.OptionData();
                newOption.text = weapon.WeaponName;
                _allWeaponsDropdown.options.Add(newOption);
            }
        }

    }
}