using Data.Other;

namespace Data.Interfaces
{
    public interface IEquipment
    {
        decimal PricePerDay { get; set; }

        string Name { get; set; }

        CoefficientContainer Coefficients { get; }
    }
}
