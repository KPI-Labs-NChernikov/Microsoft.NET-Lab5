using Data.Other;

namespace Data.Models
{
    public class Customer
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Tariff Tariff { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string FullName => $"{LastName} {FirstName}";
    }
}
