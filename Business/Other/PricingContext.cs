using Business.Interfaces;
using Data.Interfaces;

namespace Business.Other
{
    public class PricingContext
    {
        private IPricingStrategy _strategy;

        public IPricingStrategy Strategy
        {
            set
            {
                _strategy = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public PricingContext(IPricingStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public decimal GetRentalCost(IEquipment equipment, TimeSpan time)
            => _strategy.GetRentalPrice(equipment) * (decimal)time.TotalDays;
    }
}
