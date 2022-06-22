using Data;

namespace Presentation.Interfaces
{
    public interface IDataSeeder
    {
        Shop Shop { get; }

        void SeedData();
    }
}
