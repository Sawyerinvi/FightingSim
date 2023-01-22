using UnityEngine;

namespace FightingSim.Assets.Scripts.System
{
    [CreateAssetMenu(fileName = "Base Stats", menuName = "Fight Sim/Base Stats")]
    public class BaseStats : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private int _stamina;
        [SerializeField] private int _mind;
        [SerializeField] private int _endurance;
        [SerializeField] private int _strenght;
        [SerializeField] private int _dexterity;
        [SerializeField] private int _intellegence;
        [SerializeField] private int _faith;
        [SerializeField] private int _arcane;
        [SerializeField] private int _luck;

        public int Health => _health;
        public int Stamina => _stamina;
        public int Mind => _mind;
        public int Endurance => _endurance;
        public int Strenght => _strenght;
        public int Dexterity => _dexterity;
        public int Intellegence => _intellegence;
        public int Faith => _faith;
        public int Arcane => _arcane;
        public int Luck => _luck;

        public void ChangeStats(FighterStats newStats)
        {
            _health = newStats.Health;
            _stamina = newStats.Stamina;
            _mind = newStats.Mind;
            _endurance = newStats.Endurance;
            _strenght = newStats.Strenght;
            _dexterity = newStats.Dexterity;
            _intellegence = newStats.Intellegence;
            _faith = newStats.Faith;
            _arcane = newStats.Arcane;
            _luck = newStats.Luck;
        }
    }
}