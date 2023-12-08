using Business.Entities.Constants;
using Business.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CommonVehicleFeeCalculator : IFeeCalculatorFactory
    {
        // Basic user fee for common vehicle
        public decimal CalculateBasicUserFeeCost(Vehicle vehicle)
        {
            decimal basicUserFee = vehicle.BasePrice * VariedConstants.basicUserFeeRate;
            basicUserFee = Math.Min(Math.Max(basicUserFee, VariedConstants.minbasicComminFeeRate), VariedConstants.maxbasicCommonFeeRate);
            return basicUserFee;
        }

        // Seller's special fee for common vehicle
        public decimal CalculateSellerUserFeeCost(Vehicle vehicle)
        {
            decimal sellersSpecialFee = vehicle.BasePrice * VariedConstants.sellerCommonFeeRate;
            return  sellersSpecialFee;
        }

    }
}
