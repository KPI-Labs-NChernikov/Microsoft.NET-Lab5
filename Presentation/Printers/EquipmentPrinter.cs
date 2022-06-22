using Business.Managers;
using Data.Interfaces;
using Presentation.Helpers;
using Presentation.Interfaces;
using Presentation.Stringifiers;

namespace Presentation.Printers
{
    public class EquipmentPrinter : IPrinter
    {
        private readonly IEquipment _equipment;

        private readonly RentalManager _manager;

        public string? CategoryName { get; set; }

        public EquipmentPrinter(IEquipment equipment, RentalManager manager)
        {
            _equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public void Print()
        {
            HelperMethods.PrintHeader(HelperMethods
                .GetHeader($"{CategoryName} {_equipment.Make} {_equipment.Model}".TrimStart()));
            var stringifier = new EquipmentStringifier(_equipment) { Manager = _manager};
            Console.WriteLine(stringifier.Stringify());
            var dialog = new Dialog
            {
                Question = "Do you want to calculate the price for your rental term?",
                YAction = () =>
                {
                    PrintCost(GetCalculationTimeSpan());
                }
            };
            dialog.Print();
            HelperMethods.Continue();
        }

        public TimeSpan GetCalculationTimeSpan()
        {
            static string GetNumberOfString(string s) => $"the number of {s}";
            Console.WriteLine();
            var form = new NumberForm<int>
            {
                Parser = int.TryParse,
                Max = 30,
                Min = 0,
                Name = GetNumberOfString("days")
            };
            var span = TimeSpan.FromDays(form.GetNumber());
            form.Max = 23;
            form.Name = GetNumberOfString("hours");
            span = span.Add(TimeSpan.FromHours(form.GetNumber()));
            Console.WriteLine();
            if (span == new TimeSpan())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Both days and hours cannot be null");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                span = GetCalculationTimeSpan();
            }
            return span;
        }

        public void PrintCost(TimeSpan span)
        {
            Console.WriteLine($"The rent for {new TimeSpanStringifier(span).Stringify()}" +
                $" will cost you {_manager.GetRentalCost(_equipment, span):F2} UAH");
            Console.WriteLine("Do you want to rent it? Call +380682777777");
            Console.WriteLine();
        }
    }
}
