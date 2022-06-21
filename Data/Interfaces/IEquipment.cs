using Data.Models.Equipment;
using Data.Other;

namespace Data.Interfaces
{
    public interface IEquipment
    {
        decimal PricePerDay { get; set; }

        Make Make { get; set; }

        string Model { get; set; }

        CoefficientContainer Coefficients { get; }
    }
}
