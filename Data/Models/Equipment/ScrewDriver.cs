using Data.Interfaces;
using Data.Other;

namespace Data.Models.Equipment
{
    public class ScrewDriver : IEquipment
    {
        public decimal PricePerDay { get; set; }

        public string Name { get; set; } = string.Empty;

        public double MaxRotationSpeed { get; set; }

        public ushort Power { get; set; }

        public CoefficientContainer Coefficients => new() { Sale = 0.2m };

        public override string ToString()
        {
            return $"Screw driver {Name}{Environment.NewLine}" +
                $"Max rotation speed: {MaxRotationSpeed:F2} rounds/minute{Environment.NewLine}" +
                $"Power: {Power} W";
        }
    }
}
