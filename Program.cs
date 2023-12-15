using System;

namespace BossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            GameCharacter Hero = new GameCharacter(100, 20, 40);
            GameCharacter Boss = new GameCharacter(400, 30, 10);

            while (Boss.Health >= 0 && Hero.Health >= 0)
            {
                HeroTurn();
                BossTurn();
            }
            if (Hero.Health <= 0)
            {
                switch (Ask("Hero Lost\nDo you want to try again? y/n"))
                {
                    case "y":
                        Start();
                        break;
                    case "n":
                        Environment.Exit(1);
                        break;
                }
            }
            else
            {
                switch (Ask("Hero Won\nDo you want to try again? y/n"))
                {
                    case "y":
                        Start();
                        break;
                    case "n":
                        Environment.Exit(1);
                        break;
                }
            }

            void HeroTurn()
            {
                switch (AskInt("Hero's Turn:\n1. Fight\n2. Recharge"))
                {
                    case 1:
                        if (Hero.Stamina >= 10) Hero.Fight(Hero, Boss);
                        else
                        {
                            Console.WriteLine("Sorry, not enough stamina.");
                            HeroTurn();
                        }
                        break;
                    case 2:
                        Hero.Recharge("Hero");
                        break;
                }
            }

            void BossTurn()
            {
                Console.WriteLine("Boss's Turn:");
                if (Boss.Stamina >= 10) Boss.Fight(Hero, Boss);
                else Boss.Recharge("Enemy");
            }
        }

        private static string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private static int AskInt(string question)
        {
            return Convert.ToInt32(Ask(question));
        }
    }
}
