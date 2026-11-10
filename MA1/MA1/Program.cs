using System;
using DeliveryApp.Services;
using DeliveryApp.Transport;
using DeliveryApp.Payments;

namespace DeliveryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DeliveryService service = new DeliveryService();

            Console.WriteLine("\n=== СТВОРЕННЯ ТРАНСПОРТУ ===");

            service.AddTransport(new Bike(1, 15));
            service.AddTransport(new Car(2, 500));
            service.AddTransport(new Truck(3, 5000));
            service.AddTransport(new Car(1, 300));

            Console.WriteLine("\n=== СТВОРЕННЯ ЗАМОВЛЕНЬ ===");

            service.CreateOrder(101, "Документи", 2, 5);
            service.CreateOrder(102, "Побутова техніка", 100, 15);
            service.CreateOrder(103, "Великий вантаж", 600, 20);
            service.CreateOrder(104, "Дуже великий вантаж", 6000, 25);
            service.CreateOrder(105, "Продукти", 5, 3);

            service.CreateOrder(106, "", 10, 5);
            service.CreateOrder(101, "Повторне замовлення", 10, 5);

            Console.WriteLine("\n=== ВАРТІСТЬ ДОСТАВКИ ===");

            service.ShowPrices(101);
            service.ShowPrices(102);
            service.ShowPrices(104);
            service.ShowPrices(999);

            Console.WriteLine("\n=== ПРИЗНАЧЕННЯ ЗАМОВЛЕНЬ ===");
            service.AssignOrder(101, 1);
            service.AssignOrder(105, 1);
            service.AssignOrder(102, 1);
            service.AssignOrder(102, 2);
            service.AssignOrder(105, 2);
            service.AssignOrder(103, 2);
            service.AssignOrder(103, 3);
            service.AssignOrder(101, 2);
            service.AssignOrder(104, 3);
            service.AssignOrder(104, 999);

            Console.WriteLine("\n=== ДОСТАВКА ЗАМОВЛЕНЬ ===");
            service.DeliverOrder(104, new CashPayment());
            service.DeliverOrder(999, new CardPayment());
            service.DeliverOrder(101, new CardPayment());
            service.AssignOrder(105, 1);
            service.DeliverOrder(105, new CashPayment());
            service.DeliverOrder(102, new CashPayment());
            service.DeliverOrder(103, new CardPayment());
            service.ShowActiveOrders();
            service.ShowHistory();

            Console.WriteLine(
                "\n========== РОБОТУ ПРОГРАМИ ЗАВЕРШЕНО ==========");
        }
    }
}
