using Business.Interfaces;
using Data.Interfaces;

namespace Business.PricingStrategies
{
    public class StandardPricingStrategy : IPricingStrategy
    {
        public decimal GetRentalPrice(IEquipment equipment) => equipment.PricePerDay;
    }
}
