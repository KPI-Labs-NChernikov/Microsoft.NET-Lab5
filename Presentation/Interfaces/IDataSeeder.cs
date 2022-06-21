using Data;

namespace Presentation.Interfaces
{
    public interface IDataSeeder
    {
        RentalContext Context { get; }

        void SeedData();
    }
}
