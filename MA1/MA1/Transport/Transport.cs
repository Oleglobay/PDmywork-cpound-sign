using DeliveryApp.Interfaces;
using DeliveryApp.Models;

namespace DeliveryApp.Transport
{
    public abstract class Transport : ITransport
    {
        public int Id { get; }
        public string Name { get; }
        public decimal MaxWeight { get; }

        public bool IsFree { get; private set; } = true;

        protected decimal BaseCost;
        protected decimal KmCost;
        protected decimal KgCost;

        protected Transport(int id, string name,
            decimal maxWeight, decimal baseCost,
            decimal kmCost, decimal kgCost)
        {
            Id = id;
            Name = name;
            MaxWeight = maxWeight;

            BaseCost = baseCost;
            KmCost = kmCost;
            KgCost = kgCost;
        }

        public abstract decimal CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            return order != null &&
                   order.Weight <= MaxWeight;
        }

        protected decimal CalculateBaseCost(Order order)
        {
            return BaseCost +
                   KmCost * order.Distance +
                   KgCost * order.Weight;
        }

        public bool TryOccupy()
        {
            if (!IsFree)
                return false;

            IsFree = false;
            return true;
        }

        public void Release()
        {
            IsFree = true;
        }
    }
}
