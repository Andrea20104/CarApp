using Business.Entities.Constants;
using Business.Interfaces;
using Entities;

namespace Business
{
    public class LuxuryVehicleFeeCalculator : IFeeCalculatorFactory
    {
        // Basic user fee for luxury vehicle
        public decimal CalculateBasicUserFeeCost(Vehicle vehicle)
        {
            decimal basicUserFee = vehicle.BasePrice * VariedConstants.basicUserFeeRate;
            basicUserFee = Math.Min(Math.Max(basicUserFee, VariedConstants.minbasicLuxuryFeeRate), VariedConstants.maxbasicLuxuryFeeRate);

            return basicUserFee;
        }

        // Seller's special fee for luxury vehicle
        public decimal CalculateSellerUserFeeCost(Vehicle vehicle)
        {
            decimal sellersSpecialFee = vehicle.BasePrice * VariedConstants.sellerLuxuryFeeRate;
            return sellersSpecialFee;
        }

    }
}
