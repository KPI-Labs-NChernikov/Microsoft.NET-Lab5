using Data;
using Data.Models;
using Presentation.Data;
using Presentation.Helpers;
using Presentation.Printers;

Console.ForegroundColor = ConsoleColor.DarkGreen;
var shop = new Shop();
var seeder = new DataSeeder(shop);
seeder.SeedData();
HelperMethods.PrintHeader(HelperMethods.GetHeader("Start"));
var customer = new Customer();
Console.WriteLine("Hello!");
var printer = new EditableCustomerPrinter(customer);
printer.ChangeFirstName();
printer.ChangeLastName();
printer.ChangePhoneNumber();
printer.ChangeTariff();
Console.WriteLine($"Congratulations, {customer.FullName}");
Console.WriteLine($"You have been successfully registered with the tariff \"{customer.Tariff}\"");
HelperMethods.Continue();
var mainMenu = new Menu
{
    Header = HelperMethods.GetHeader("Main"),
    Name = "option",
    Items = new List<MenuItem>
    {
        new MenuItem {Text = "View profile", 
            Action = () => { var readOnlyPrinter = new CustomerPrinter(customer); readOnlyPrinter.Print(); } },
        new MenuItem {Text = "Edit profile",
            Action = () => { printer.Print(); } },
        new MenuItem {Text = "To shop",
            Action = () => { var shopPrinter = new ShopPrinter(shop); shopPrinter.Print(); } },
    }
};
mainMenu.Print();
Console.ResetColor();
