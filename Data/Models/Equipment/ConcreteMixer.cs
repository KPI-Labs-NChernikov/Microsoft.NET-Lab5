using Data.Interfaces;
using Data.Other;

namespace Data.Models.Equipment
{
    public class ConcreteMixer : IEquipment
    {
        public decimal PricePerDay { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Volume { get; set; }

        public TimeSpan KleadingTime { get; set; }

        public CoefficientContainer Coefficients => new() { Sale = 0.1m };

        public override string ToString()
        {
            return $"Concrete mixer {Name}{Environment.NewLine}Volume: {Volume:F2} litres{Environment.NewLine}" +
                $"Kleading time: {KleadingTime.Minutes} minutes, {KleadingTime.Seconds} seconds";
        }
    }
}
