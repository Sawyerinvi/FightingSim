using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using FightingSim.Assets.Scripts.System;
using FightingSim.Assets.Scripts.Player;

namespace FightingSim.Assets.Scripts.UI.PlayerUI
{
    public class CurrentTargets : MonoBehaviour
    {
        [SerializeField] private TMP_Text _targetList;
        private TargetSelect _target;

        [Inject]
        public void Construct(PlayerFacade player)
        {
            _target = player.PlayerTargets;
            _target.OnAddingTarget += StateChanged;
        }
        
        private void StateChanged(List<ISelectable> targetList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var target in targetList)
            {
                sb.Append(target.Name);
                sb.AppendLine();

            }
            _targetList.text = sb.ToString();
        }
        private void OnDestroy()
        {
            _target.OnAddingTarget -= StateChanged;
        }

    }
}