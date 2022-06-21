using Data.Models.Equipment;

namespace Data
{
    public class Shop
    {
        public ICollection<ConcreteMixer> ConcreteMixers { get; set; } = new List<ConcreteMixer>();

        public ICollection<RoadRollerCar> RoadRollerCars { get; set; } = new List<RoadRollerCar>();

        public ICollection<ScrewDriver> ScrewDrivers { get; set; } = new List<ScrewDriver>();
    }
}