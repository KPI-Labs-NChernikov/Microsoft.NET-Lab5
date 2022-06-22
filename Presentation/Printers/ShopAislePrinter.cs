using Business.Managers;
using Data.Interfaces;
using Data.Models;
using Presentation.Helpers;
using Presentation.Interfaces;
using Presentation.Stringifiers;

namespace Presentation.Printers
{
    public class ShopAislePrinter : IPrinter
    {
        private readonly IEnumerable<IEquipment> _aisle;

        private readonly Customer _customer;

        public string? Name { get; set; }

        public ShopAislePrinter(IEnumerable<IEquipment> aisle, Customer customer)
        {
            _aisle = aisle ?? throw new ArgumentNullException(nameof(aisle));
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public void Print()
        {
            var menu = new Menu
            {
                Name = "item",
                Header = string.IsNullOrEmpty(Name) ? "Aisle" : Name
            };
            var manager = new RentalManager(_customer);
            foreach (var item in _aisle)
                menu.Items.Add(new MenuItem
                {
                    Text = new EquipmentStringifier(item) { Manager = manager }.Stringify(),
                    Action = () => new EquipmentPrinter(item, manager) { CategoryName = Name?[..^1] }.Print()
                });
            menu.Print();
        }
    }
}
