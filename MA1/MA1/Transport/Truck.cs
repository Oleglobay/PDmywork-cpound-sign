using DeliveryApp.Models;

namespace DeliveryApp.Transport
{
    public class Truck : Transport
    {
        public Truck(int id, decimal maxWeight)
            : base(id, "Вантажівка", maxWeight, 200, 15, 0.5m)
        {
        }

        public override decimal CalculateCost(Order order)
        {
            return CalculateBaseCost(order);
        }
    }
}
