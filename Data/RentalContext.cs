using Data.Models;

namespace Data
{
    public class RentalContext
    {
        public Shop Shop { get; set; } = new Shop();

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
