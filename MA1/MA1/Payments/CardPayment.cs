using System;
using DeliveryApp.Interfaces;

namespace DeliveryApp.Payments
{
    public class CardPayment : IPaymentMethod
    {
        public string Name => "Картка";

        public bool Pay(decimal amount)
        {
            Console.WriteLine(
                $"Оплачено карткою: {amount:F2} грн");

            return true;
        }
    }
}
