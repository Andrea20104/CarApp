using Business.Entities.Constants;
using Business.Interfaces;
using Entities;

namespace Business
{
    public class CalculatorService : ICalculatorSercive
    {
        public AuctionCosts CalculateTotalCost(Vehicle vehicle)
        {
            ValidateRequest(vehicle);

            // Use the factory to create the appropriate calculator
            var feeCalculator = FeeCalculatorFactory.CreateCalculator(vehicle.VehicleType);

            // Calculate the cost to the vehicle type
            decimal basicFee = feeCalculator.CalculateBasicUserFeeCost(vehicle);
            decimal specialFee = feeCalculator.CalculateSellerUserFeeCost(vehicle);

            //Calculate the common costs
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

        private static void ValidateRequest(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
        }

        private decimal CalculateAssociationFee(decimal basePrice)
        {
            if (basePrice <= VariedConstants.fivehundred) return VariedConstants.amountfive;
            if (basePrice <= VariedConstants.thousand) return VariedConstants.amountten;
            if (basePrice <= VariedConstants.threethousand) return VariedConstants.amountfiftheen;

            return VariedConstants.amounttwenty;
        }
    }
}