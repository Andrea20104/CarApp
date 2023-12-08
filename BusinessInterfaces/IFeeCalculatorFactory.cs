using Business.Interfaces.Services;
using Entities;

namespace Business.Interfaces
{
    public interface IFeeCalculatorFactory : IService
    {
        decimal CalculateBasicUserFeeCost(Vehicle vehicle);
        decimal CalculateSellerUserFeeCost(Vehicle vehicle);
    }
}
