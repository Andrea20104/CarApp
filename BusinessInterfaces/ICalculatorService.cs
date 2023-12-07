using Business.Interfaces.Services;
using Entities;

namespace Business.Interfaces
{
    public interface ICalculatorService : IService
    {
        AuctionCosts CalculateTotalCost(Vehicle vehicle);
    }
}
