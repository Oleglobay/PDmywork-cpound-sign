using System;
using System.Collections.Generic;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;

namespace DeliveryApp.Services
{
    public class DeliveryService
    {
        private readonly List<ITransport> transports =
            new List<ITransport>();

        private readonly List<Order> activeOrders =
            new List<Order>();

        private readonly List<Order> history =
            new List<Order>();

        public void AddTransport(ITransport transport)
        {
            if (transport == null ||
                transports.Exists(t => t.Id == transport.Id))
            {
                Console.WriteLine("Помилка створення транспорту!");
                return;
            }

            transports.Add(transport);

            Console.WriteLine(
                $"Створено транспорт: {transport.Name}, ID: {transport.Id}");
        }

        public void CreateOrder(int number, string description,
            decimal weight, decimal distance)
        {
            if (number <= 0 || weight <= 0 || distance <= 0 ||
                string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Некоректні дані замовлення!");
                return;
            }

            bool exists =
                activeOrders.Exists(o => o.Number == number) ||
                history.Exists(o => o.Number == number);

            if (exists)
            {
                Console.WriteLine("Таке замовлення вже існує!");
                return;
            }

            Order order = new Order(
                number, description, weight, distance);

            activeOrders.Add(order);

            Console.WriteLine($"Створено замовлення №{number}");
        }

        public void ShowPrices(int orderNumber)
        {
            Order order = activeOrders.Find(
                o => o.Number == orderNumber);

            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдено!");
                return;
            }

            Console.WriteLine(
                $"\nВартість доставки замовлення №{orderNumber}:");

            bool found = false;

            foreach (ITransport transport in transports)
            {
                if (transport.CanTake(order))
                {
                    found = true;

                    Console.WriteLine(
                        $"{transport.Name} | " +
                        $"{transport.CalculateCost(order):F2} грн | " +
                        $"{(transport.IsFree ? "Вільний" : "Зайнятий")}");
                }
            }

            if (!found)
            {
                Console.WriteLine("Немає придатного транспорту!");
            }
        }

        public void AssignOrder(int orderNumber, int transportId)
        {
            Order order = activeOrders.Find(
                o => o.Number == orderNumber);

            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдено!");
                return;
            }

            if (order.AssignedTransport != null)
            {
                Console.WriteLine("Замовлення вже призначене!");
                return;
            }

            ITransport transport = transports.Find(
                t => t.Id == transportId);

            if (transport == null)
            {
                Console.WriteLine("Транспорт не знайдено!");
                return;
            }

            if (!transport.CanTake(order))
            {
                Console.WriteLine(
                    "Транспорт не може взяти це замовлення!");
                return;
            }

            if (!transport.TryOccupy())
            {
                Console.WriteLine("Транспорт вже зайнятий!");
                return;
            }

            order.AssignTransport(transport);

            Console.WriteLine(
                $"Замовлення №{orderNumber} призначено на {transport.Name}.");
        }

        public void DeliverOrder(
            int orderNumber, IPaymentMethod payment)
        {
            Order order = activeOrders.Find(
                o => o.Number == orderNumber);

            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдено!");
                return;
            }

            if (order.AssignedTransport == null)
            {
                Console.WriteLine("Транспорт не призначено!");
                return;
            }

            if (payment == null)
            {
                Console.WriteLine("Спосіб оплати не вказано!");
                return;
            }

            decimal cost =
                order.AssignedTransport.CalculateCost(order);

            Console.WriteLine(
                $"\nДоставка замовлення №{orderNumber}");

            if (!payment.Pay(cost))
            {
                Console.WriteLine("Оплату не виконано!");
                return;
            }

            order.AssignedTransport.Release();

            order.Complete(payment.Name);

            history.Add(order);
            activeOrders.Remove(order);

            Console.WriteLine("Замовлення доставлено!");
            Console.WriteLine("Транспорт звільнено.");
            Console.WriteLine("Замовлення переміщено в історію.");
        }

        public void ShowActiveOrders()
        {
            Console.WriteLine(
                "\n========== АКТИВНІ ЗАМОВЛЕННЯ ==========");

            if (activeOrders.Count == 0)
            {
                Console.WriteLine("Активних замовлень немає.");
                return;
            }

            foreach (Order order in activeOrders)
            {
                Console.WriteLine($"\nНомер: {order.Number}");
                Console.WriteLine($"Опис: {order.Description}");
                Console.WriteLine($"Вага: {order.Weight} кг");
                Console.WriteLine($"Відстань: {order.Distance} км");
                Console.WriteLine($"Статус: {order.Status}");

                Console.WriteLine(
                    "Транспорт: " +
                    (order.AssignedTransport?.Name ?? "Не призначено"));
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine(
                "\n========== ІСТОРІЯ ДОСТАВОК ==========");

            if (history.Count == 0)
            {
                Console.WriteLine("Історія порожня.");
                return;
            }

            foreach (Order order in history)
            {
                Console.WriteLine($"\nНомер: {order.Number}");
                Console.WriteLine($"Опис: {order.Description}");
                Console.WriteLine($"Вага: {order.Weight} кг");
                Console.WriteLine($"Відстань: {order.Distance} км");

                Console.WriteLine(
                    $"Транспорт: {order.AssignedTransport.Name}");

                Console.WriteLine(
                    $"Вартість: " +
                    $"{order.AssignedTransport.CalculateCost(order):F2} грн");

                Console.WriteLine($"Оплата: {order.PaymentMethod}");
                Console.WriteLine($"Статус: {order.Status}");
            }
        }
    }
}
