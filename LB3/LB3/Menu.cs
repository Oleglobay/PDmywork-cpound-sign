using System;

namespace HunterGame
{
    internal class Menu
    {
        public void Start(Hunter h1, Hunter h2)
        {
            int choice;
            int hunterChoice;

            do
            {
                Console.WriteLine("\n===== МЕНЮ =====");
                Console.WriteLine("1. Полювати");
                Console.WriteLine("2. Купити стріли");
                Console.WriteLine("3. Інформація про мисливця");
                Console.WriteLine("4. Завершити змагання");
                Console.Write("Ваш вибір: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Введіть число!");
                    continue;
                }

                if (choice >= 1 && choice <= 3)
                {
                    Console.WriteLine("\n1. " + h1.GetName());
                    Console.WriteLine("2. " + h2.GetName());
                    Console.Write("Оберіть мисливця: ");

                    if (!int.TryParse(Console.ReadLine(), out hunterChoice))
                    {
                        Console.WriteLine("Введіть число!");
                        continue;
                    }

                    Hunter hunter = null;

                    if (hunterChoice == 1)
                        hunter = h1;
                    else if (hunterChoice == 2)
                        hunter = h2;
                    else
                    {
                        Console.WriteLine("Неправильний вибір!");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            hunter.Hunt();
                            break;

                        case 2:
                            hunter.BuyArrows();
                            break;

                        case 3:
                            hunter.ShowInfo();
                            break;
                    }
                }
                else if (choice != 4)
                {
                    Console.WriteLine("Неправильний пункт меню!");
                }

            } while (choice != 4);
        }

        public void Results(Hunter h1, Hunter h2)
        {
            Console.WriteLine("\n===== РЕЗУЛЬТАТИ =====");

            h1.ShowInfo();
            h2.ShowInfo();

            Console.WriteLine("\n===== ПЕРЕМОЖЕЦЬ =====");

            if (h1.GetLoot() > h2.GetLoot())
            {
                Console.WriteLine("Переможець: " + h1.GetName());
            }
            else if (h2.GetLoot() > h1.GetLoot())
            {
                Console.WriteLine("Переможець: " + h2.GetName());
            }
            else
            {
                Console.WriteLine("Нічия!");
            }
        }
    }
}
