using Business.Interfaces;

namespace Business
{
    public static class FeeCalculatorFactory
    {
        public static IFeeCalculatorFactory CreateCalculator(string vehicleType)
        {
            if (vehicleType == "Common")
                return new CommonVehicleFeeCalculator();
            else if (vehicleType == "Luxury")
                return new LuxuryVehicleFeeCalculator();
            else
                throw new ArgumentException("Invalid vehicle type");
        }
    }
}
