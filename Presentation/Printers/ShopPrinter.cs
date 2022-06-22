using Data;
using Data.Models;
using Presentation.Helpers;
using Presentation.Interfaces;

namespace Presentation.Printers
{
    public class ShopPrinter : IPrinter
    {
        private readonly Shop _shop;

        private readonly Customer _customer;

        public ShopPrinter(Shop shop, Customer customer)
        {
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public void Print()
        {
            var aisleNames = new string[]
            {
                "Concrete mixers",
                "Road roller cars",
                "Screw drivers"
            };
            var menu = new Menu
            {
                Name = "category",
                Header = "Shop",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Text = aisleNames[0],
                        Action = () =>
                        {
                            var printer = new ShopAislePrinter(_shop.ConcreteMixers, _customer){Name = aisleNames[0]};
                            printer.Print();
                        }
                    },
                    new MenuItem
                    {
                        Text = aisleNames[1],
                        Action = () =>
                        {
                            var printer = new ShopAislePrinter(_shop.RoadRollerCars, _customer){Name = aisleNames[1]};
                            printer.Print();
                        }
                    },
                    new MenuItem
                    {
                        Text = aisleNames[2],
                        Action = () =>
                        {
                            var printer = new ShopAislePrinter(_shop.ScrewDrivers, _customer){Name = aisleNames[2]};
                            printer.Print();
                        }
                    }
                }
            };
            menu.Print();
        }
    }
}
