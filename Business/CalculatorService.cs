using Business.Entities.Constants;
using Business.Interfaces;
using Entities;

namespace Business
{
    public class CalculatorService : ICalculatorService
    {
        public AuctionCosts CalculateTotalCost(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            decimal basicFee = CalculateBasicFee(vehicle.BasePrice, vehicle.VehicleType);
            decimal specialFee = CalculateSpecialFee(vehicle.BasePrice, vehicle.VehicleType);
            decimal associationFee = CalculateAssociationFee(vehicle.BasePrice);
            decimal storageFee = VariedConstants.storageFee; 

            decimal totalcost = vehicle.BasePrice + basicFee + specialFee + associationFee + storageFee;

            AuctionCosts costs = new AuctionCosts()
            {
                BasicUserFee = basicFee,
                SellersSpecialFee = specialFee,
                AssociationFee = associationFee,
                StorageFee = storageFee,
                TotalCost = totalcost
            };

            return costs;
        }

        private decimal CalculateBasicFee(decimal basePrice, string vehicleType)
        {
            decimal basicFeeRate = VariedConstants.basicFeeRate;
            decimal minBasicFee = GetMinBasicFee(vehicleType);
            decimal maxBasicFee = GetMaxBasicFee(vehicleType);

            decimal basicFee = basePrice * basicFeeRate;

            return Clamp(basicFee, minBasicFee, maxBasicFee);
        }

        private decimal CalculateSpecialFee(decimal basePrice, string vehicleType)
        {
            decimal specialFeeRate = GetSpecialFeeRate(vehicleType);

            return basePrice * specialFeeRate;
        }

        private decimal CalculateAssociationFee(decimal basePrice)
        {
            if (basePrice <= 500m) return VariedConstants.amountfive;
            if (basePrice <= 1000m) return VariedConstants.amountten;
            if (basePrice <= 3000m) return VariedConstants.amountfiftheen;

            return VariedConstants.amounttwenty;
        }


        private decimal GetMinBasicFee(string vehicleType)
        {
            return vehicleType.Equals(VariedConstants.vehicleTypeLuxury, StringComparison.OrdinalIgnoreCase) ? 25m : 10m;
        }

        private decimal GetMaxBasicFee(string vehicleType)
        {
            return vehicleType.Equals(VariedConstants.vehicleTypeLuxury, StringComparison.OrdinalIgnoreCase) ? 200m : 50m;
        }

        private decimal GetSpecialFeeRate(string vehicleType)
        {
            return vehicleType.Equals(VariedConstants.vehicleTypeLuxury, StringComparison.OrdinalIgnoreCase) ? 0.04m : 0.02m;
        }

        private decimal Clamp(decimal value, decimal min, decimal max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
    }
}