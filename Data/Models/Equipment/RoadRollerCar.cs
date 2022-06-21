using Data.Interfaces;
using Data.Other;

namespace Data.Models.Equipment
{
    public class RoadRollerCar : IEquipment
    {
        public decimal PricePerDay { get; set; }

        public string Name { get; set; } = string.Empty;

        public Roller Roller { get; set; } = new Roller();

        public double MaxSpeed { get; set; }

        public CoefficientContainer Coefficients => new() { Penalty = 0.3m, Sale = 0.05m };

        public override string ToString()
        {
            return $"Road roller car {Name}{Environment.NewLine}{Roller}{Environment.NewLine}" +
                $"Max speed: {MaxSpeed:F2} km/h";
        }
    }
}
