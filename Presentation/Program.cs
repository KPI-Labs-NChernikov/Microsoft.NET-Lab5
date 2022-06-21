using Data;
using Presentation.Data;

Console.ForegroundColor = ConsoleColor.DarkGreen;
var context = new RentalContext();
var seeder = new DataSeeder(context);
seeder.SeedData();
Console.WriteLine("Hello world");