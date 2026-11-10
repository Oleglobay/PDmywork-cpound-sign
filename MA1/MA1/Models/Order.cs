using DeliveryApp.Interfaces;

namespace DeliveryApp.Models
{
    public class Order
    {
        public int Number { get; }
        public string Description { get; }
        public decimal Weight { get; }
        public decimal Distance { get; }

        public ITransport AssignedTransport { get; private set; }

        public string PaymentMethod { get; private set; }
        public string Status { get; private set; }

        public Order(int number, string description,
            decimal weight, decimal distance)
        {
            Number = number;
            Description = description;
            Weight = weight;
            Distance = distance;

            Status = "Нове";
        }

        public void AssignTransport(ITransport transport)
        {
            AssignedTransport = transport;
            Status = "Призначено";
        }

        public void Complete(string payment)
        {
            PaymentMethod = payment;
            Status = "Доставлено";
        }
    }
}
