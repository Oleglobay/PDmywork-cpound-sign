using DeliveryApp.Models;

namespace DeliveryApp.Transport
{
    public class Bike : Transport
    {
        public Bike(int id, decimal maxWeight)
            : base(id, "Велосипед", maxWeight, 20, 5, 0)
        {
        }

        public override decimal CalculateCost(Order order)
        {
            return CalculateBaseCost(order);
        }

        public override bool CanTake(Order order)
        {
            return base.CanTake(order) &&
                   order.Distance <= 10;
        }
    }
}
