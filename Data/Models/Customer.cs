using Data.Other;

namespace Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Tariff Tariff { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string HashPassword { get; set; } = string.Empty;

        public string FullName => $"{LastName} {FirstName}";


        public ICollection<Role> Roles = new List<Role> { Role.User };
    }
}
