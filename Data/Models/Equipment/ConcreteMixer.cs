using Data.Interfaces;
using Data.Other;

namespace Data.Models.Equipment
{
    public class ConcreteMixer : IEquipment
    {
        public decimal PricePerDay { get; set; }

        public Make Make { get; set; } = new();

        public string Model { get; set; } = string.Empty;

        public double Volume { get; set; }

        public CoefficientContainer Coefficients => new() { Sale = 0.1m };

        public override string ToString()
        {
            return $"Concrete mixer {Make} {Model}{Environment.NewLine}Volume: {Volume:F2} litres";
        }
    }
}
