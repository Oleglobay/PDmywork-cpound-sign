
using System;

namespace HunterGame
{
    internal class Hunter
    {
        private string name;
        private int health;
        private int gold;
        private int arrows;
        private int loot;

        private static Random random = new Random();

        public Hunter(string n, int h, int g, int a)
        {
            name = n;
            health = h;
            gold = g;
            arrows = a;
            loot = 0;
        }

        public void Hunt()
        {
            if (health <= 0)
            {
                Console.WriteLine($"{name} не має здоров'я!");
                return;
            }

            if (arrows <= 0)
            {
                Console.WriteLine($"{name} не має стріл!");
                return;
            }

            arrows--;

            if (random.Next(2) == 1)
            {
                loot++;
                gold += 20;

                Console.WriteLine($"{name} отримав здобич і 20 золота!");
            }
            else
            {
                health -= 20;

                if (health < 0)
                    health = 0;

                Console.WriteLine($"{name} втратив 20 здоров'я!");
            }
        }

        public void BuyArrows()
        {
            if (gold >= 10)
            {
                gold -= 10;
                arrows += 5;

                Console.WriteLine($"{name} купив 5 стріл!");
            }
            else
            {
                Console.WriteLine("Недостатньо золота!");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\n--- {name} ---");
            Console.WriteLine($"Здоров'я: {health}");
            Console.WriteLine($"Золото: {gold}");
            Console.WriteLine($"Стріли: {arrows}");
            Console.WriteLine($"Здобич: {loot}");
        }

        public int GetLoot()
        {
            return loot;
        }

        public string GetName()
        {
            return name;
        }
    }
}
