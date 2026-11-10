using DeliveryApp.Models; 

namespace DeliveryApp.Interfaces
{
    public interface ITransport
    {
        int Id { get; }
        string Name { get; }
        bool IsFree { get; }

        bool CanTake(Order order);
        decimal CalculateCost(Order order);

        bool TryOccupy();
        void Release();
    }
}
