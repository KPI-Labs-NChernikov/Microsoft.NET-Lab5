using Data;
using Data.Models;

namespace Business.Managers
{
    public class CustomerManager
    {
        public RentalContext Context { get; }

        private static int _id = 1;

        public Func<string, bool>? IsValidPhoneNumber { get; set; } = s =>
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return s.First() == '+' && s.Length >= 5 && s[1..].All(c => char.IsDigit(c));
        };

        public CustomerManager(RentalContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Customer customer, string password)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            if (Context.Customers.Any(c => c.PhoneNumber == customer.PhoneNumber))
                throw new InvalidOperationException("User with such a phone number already exists");
            if (IsValidPhoneNumber != null && !IsValidPhoneNumber.Invoke(customer.PhoneNumber))
                throw new ArgumentException("The phone number is not valid", nameof(customer));
            customer.Id = _id;
            var manager = new CustomerPasswordManager(customer);
            manager.ResetPassword(password);
            Context.Customers.Add(customer);
            _id++;
        }

        public void ChangePhoneNumber(Customer customer, string phoneNumber)
        {
            if (Context.Customers.Any(c => c.PhoneNumber == customer.PhoneNumber))
                throw new InvalidOperationException("User with such a phone number already exists");
            if (IsValidPhoneNumber != null && !IsValidPhoneNumber.Invoke(customer.PhoneNumber))
                throw new ArgumentException("The phone number is not valid", nameof(customer));
            customer.PhoneNumber = phoneNumber;
        }

        public void DeleteById(int id)
        {
            Context.Customers.Remove(Context.Customers.First(c => c.Id == id));
        }

        public Customer? FindByPhoneNumber(string phoneNumber)
        {
            return Context.Customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        }
    }
}
