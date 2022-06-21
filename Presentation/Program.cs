using Data;
using Presentation.Data;
using Presentation.Helpers;

Console.ForegroundColor = ConsoleColor.DarkGreen;
var context = new RentalContext();
var seeder = new DataSeeder(context);
seeder.SeedData();
var mainMenu = new Menu
{
    Header = HelperMethods.GetHeader("Main"),
    Name = "option",
    Items = new List<MenuItem>
    {
        new MenuItem { Text = "Log in" },
        new MenuItem { Text = "Register" }
    }
};
mainMenu.Print();
Console.ResetColor();
