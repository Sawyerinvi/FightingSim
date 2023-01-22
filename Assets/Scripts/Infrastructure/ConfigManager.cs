using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

namespace FightingSim.Assets.Scripts.Infrastructure
{
    [CreateAssetMenu(fileName = "Config Manager", menuName = "Fight Sim/Config Manager")]
    public class ConfigManager : ScriptableObject
    {

        [SerializeField] private List<Config> _dataList;

        public T GetConfig<T>() where T : Config
        {
            foreach (var type in _dataList)
            {
                if (type is T) return type as T;
            }
            return null;
        }
    }
}


