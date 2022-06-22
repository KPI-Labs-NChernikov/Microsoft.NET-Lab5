using Data;
using Presentation.Interfaces;

namespace Presentation.Printers
{
    public class ShopPrinter : IPrinter
    {
        private readonly Shop _shop;

        public ShopPrinter(Shop shop)
        {
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
