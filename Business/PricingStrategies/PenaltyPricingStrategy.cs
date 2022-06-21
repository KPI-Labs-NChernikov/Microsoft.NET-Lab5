using Business.Interfaces;
using Data.Interfaces;

namespace Business.PricingStrategies
{
    public class PenaltyPricingStrategy : IPricingStrategy
    {
        public decimal GetRentalPrice(IEquipment equipment)
        {
            return equipment.PricePerDay * (1m + equipment.Coefficients.Penalty);
        }
    }
}
