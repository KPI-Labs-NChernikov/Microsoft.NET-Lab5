using Data;
using Data.Models;

namespace Business.Managers
{
    public class CustomerManager
    {
        public RentalContext Context { get; }

        private static int _id = 1;

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
            customer.Id = _id;
            var manager = new CustomerPasswordManager(customer);
            manager.ResetPassword(password);
            Context.Customers.Add(customer);
            _id++;
        }

        public void DeleteById(int id)
        {
            Context.Customers.Remove(Context.Customers.First(c => c.Id == id));
        }
    }
}
