using DeliveryApp.Models;

namespace DeliveryApp.Transport
{
    public class Car : Transport
    {
        public Car(int id, decimal maxWeight)
            : base(id, "Автомобіль", maxWeight, 50, 8, 1)
        {
        }

        public override decimal CalculateCost(Order order)
        {
            return CalculateBaseCost(order);
        }
    }
}
