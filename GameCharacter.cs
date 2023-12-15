using System;

namespace BossFight
{
    internal class GameCharacter
    {
        Random random = new Random();

        public int Health;
        public int Strength;
        public int Stamina;
        private int _originStamina;

        public GameCharacter(int health, int strength, int stamina)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
            _originStamina = stamina;
        }

        public void Fight(GameCharacter Hero, GameCharacter Boss)
        {
            if (Strength != 20)
            {
                int bossStrength = random.Next(0, Strength);
                Hero.Health -= bossStrength;
                Console.WriteLine($"Enemy Hit Hero with {bossStrength} damage, Hero now has {Hero.Health} health left.");
                Boss.Stamina -= 10;
            }
            else
            {
                Boss.Health -= Strength;
                Console.WriteLine($"Hero hit Enemy with {Strength} damage, Enemy now has {Boss.Health} health left.");
                Hero.Stamina -= 10;
            }
        }

        public void Recharge(string current)
        {
            Stamina = _originStamina;
            Console.WriteLine($"{current} recharged back up to {_originStamina} stamina");
        }
    }
}
