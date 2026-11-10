using System;

namespace HunterGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =
                System.Text.Encoding.UTF8;

            Hunter hunter1 = new Hunter("Олег", 100, 50, 5);
            Hunter hunter2 = new Hunter("Андрій", 100, 50, 5);

            Menu menu = new Menu();

            Console.WriteLine("===== ЗМАГАННЯ МИСЛИВЦІВ =====");

            hunter1.ShowInfo();
            hunter2.ShowInfo();

            menu.Start(hunter1, hunter2);
            menu.Results(hunter1, hunter2);

            Console.WriteLine("\nПрограму завершено!");
        }
    }
}
