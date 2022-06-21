using Data.Interfaces;

namespace Business.Interfaces
{
    public interface IPricingStrategy
    {
        decimal GetRentalPrice(IEquipment equipment);
    }
}
