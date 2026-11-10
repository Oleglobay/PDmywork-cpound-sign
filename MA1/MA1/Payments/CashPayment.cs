using System;
using DeliveryApp.Interfaces;

namespace DeliveryApp.Payments
{
    public class CashPayment : IPaymentMethod
    {
        public string Name => "Готівка";

        public bool Pay(decimal amount)
        {
            Console.WriteLine(
                $"Оплачено готівкою: {amount:F2} грн");

            return true;
        }
    }
}
