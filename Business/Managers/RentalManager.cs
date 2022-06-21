using Business.Interfaces;
using Business.Other;
using Business.PricingStrategies;
using Data.Interfaces;
using Data.Models;
using Data.Other;

namespace Business.Managers
{
    public class RentalManager
    {
        private readonly PricingContext _context;

        private Tariff _lastTariff;

        private Customer _customer;

        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public RentalManager(Customer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
            _lastTariff = customer.Tariff;
            _context = new PricingContext(GetStrategy(_lastTariff));
        }

        private static IPricingStrategy GetStrategy(Tariff tariff)
        {
            IPricingStrategy strategy = tariff switch
            {
                Tariff.Penalty => new PenaltyPricingStrategy(),
                Tariff.Preferential => new PreferentialPricingStrategy(),
                _ => new StandardPricingStrategy(),
            };
            return strategy;
        }


        public decimal GetRentalCost(IEquipment equipment, TimeSpan time)
        {
            if (_customer.Tariff != _lastTariff)
            {
                _lastTariff = _customer.Tariff;
                _context.Strategy = GetStrategy(_lastTariff);
            }
            return _context.GetRentalCost(equipment, time);
        }
    }
}
