namespace FightingSim.Assets.Scripts.System
{
    public struct FighterStats
    {
        public readonly int Health;
        public readonly int Stamina;
        public readonly int Mind;
        public readonly int Endurance;
        public readonly int Strenght;
        public readonly int Dexterity;
        public readonly int Intellegence;
        public readonly int Faith;
        public readonly int Arcane;
        public readonly int Luck;

        public FighterStats(int health, int stamina, int mind, int endurance, int strenght, int dexterity, int intellegence, int faith,
            int arcane, int luck)
        {
            Health = health;
            Stamina = stamina;
            Mind = mind;
            Endurance = endurance;
            Strenght = strenght;
            Dexterity = dexterity;
            Intellegence = intellegence;
            Faith = faith;
            Arcane = arcane;
            Luck = luck;
        }

    }
}