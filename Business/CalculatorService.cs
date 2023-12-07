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
            decimal storageFee = 100m; // Fixed storage fee

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
            decimal basicFeeRate = 0.1m;
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
            if (basePrice <= 500m) return 5m;
            if (basePrice <= 1000m) return 10m;
            if (basePrice <= 3000m) return 15m;

            return 20m;
        }

        private decimal GetBasicFeeRate(string vehicleType)
        {
            return vehicleType.Equals("Luxury", StringComparison.OrdinalIgnoreCase) ? 0.1m : 0.02m;
        }

        private decimal GetMinBasicFee(string vehicleType)
        {
            return vehicleType.Equals("Luxury", StringComparison.OrdinalIgnoreCase) ? 25m : 10m;
        }

        private decimal GetMaxBasicFee(string vehicleType)
        {
            return vehicleType.Equals("Luxury", StringComparison.OrdinalIgnoreCase) ? 200m : 50m;
        }

        private decimal GetSpecialFeeRate(string vehicleType)
        {
            return vehicleType.Equals("Luxury", StringComparison.OrdinalIgnoreCase) ? 0.04m : 0.02m;
        }

        private decimal Clamp(decimal value, decimal min, decimal max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
    }
}