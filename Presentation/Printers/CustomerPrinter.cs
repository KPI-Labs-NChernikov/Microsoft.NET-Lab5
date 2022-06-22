using Data.Models;
using Presentation.Helpers;

namespace Presentation.Printers
{
    public class CustomerPrinter
    {
        private readonly Customer _customer;

        public CustomerPrinter(Customer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public void Print()
        {
            HelperMethods.PrintHeader(HelperMethods.GetHeader("Profile"));
            Console.WriteLine(_customer);
            HelperMethods.Continue();
        }
    }
}
