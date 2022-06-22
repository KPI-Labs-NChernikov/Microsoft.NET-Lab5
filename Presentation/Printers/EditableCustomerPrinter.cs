using Data.Models;
using Data.Other;
using Presentation.Helpers;
using Presentation.Interfaces;

namespace Presentation.Printers
{
    public class EditableCustomerPrinter : IPrinter
    {
        private readonly Customer _customer;

        public EditableCustomerPrinter(Customer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public void Print()
        {
            static void PrintAfter(string propertyName, string result)
            {
                Console.WriteLine($"The {propertyName} has been successfully updated to {result}");
                HelperMethods.Continue();
            }

            HelperMethods.PrintHeader(HelperMethods.GetHeader("Edit profile"));
            Console.WriteLine(_customer);
            var menu = new LiteMenu
            {
                IsQuitable = true,
                Name = "property to update",
                Items = new List<MenuItem>
                {
                    new MenuItem{ Text = "First name",
                    Action = () =>
                    {
                        ChangeFirstName(true);
                        PrintAfter("first name", _customer.FirstName);

                    }},
                    new MenuItem{ Text = "Last name",
                    Action = () =>
                    {
                        ChangeLastName(true);
                        PrintAfter("last name", _customer.LastName);

                    }},
                    new MenuItem{ Text = "Phone number",
                    Action = () =>
                    {
                        ChangePhoneNumber(true);
                        PrintAfter("phone number", _customer.PhoneNumber);
                    }},
                    new MenuItem{ Text = "Tariff",
                    Action = () =>
                    {
                        ChangeTariff(true);
                        PrintAfter("tariff", _customer.Tariff.ToString());
                    }},
                }
            };
            menu.Print();
        }

        private readonly IReadOnlyDictionary<string, ValidationItem> _validators
            = new Dictionary<string, ValidationItem>
        {
            {"whiteSpace", 
                new ValidationItem{ 
                    Validate = s => !string.IsNullOrWhiteSpace(s), 
                    ErrorMessage = "this field shouldn't be empty" 
                } },
            {"phoneNumber",
                new ValidationItem{
                    Validate = s => s != null && s.Length >= 5 && s.Length <= 16 
                        && s.First() == '+' && s[1..].All(c => char.IsDigit(c)),
                    ErrorMessage = "this field shouldn't be empty"
                } },
        };

        private static string GetNamePrefix(bool printNew) => printNew ? "new " : string.Empty;

        public void ChangeFirstName(bool printNew = false)
        {
            var validationItem = _validators["whiteSpace"];
            var form = new StringForm
            {
                IsValid = validationItem.Validate,
                Name = $"{GetNamePrefix(printNew)}first name",
                ErrorMessage = validationItem.ErrorMessage
            };
            _customer.FirstName = form.GetString();
            Console.WriteLine();
        }

        public void ChangeLastName(bool printNew = false)
        {
            var validationItem = _validators["whiteSpace"];
            var form = new StringForm
            {
                IsValid = validationItem.Validate,
                Name = $"{GetNamePrefix(printNew)}last name",
                ErrorMessage = validationItem.ErrorMessage
            };
            _customer.LastName = form.GetString();
            Console.WriteLine();
        }

        public void ChangePhoneNumber(bool printNew = false)
        {
            var validationItem = _validators["phoneNumber"];
            var form = new StringForm
            {
                IsValid = validationItem.Validate,
                Name = $"{GetNamePrefix(printNew)}phone number",
                ErrorMessage = validationItem.ErrorMessage
            };
            _customer.PhoneNumber = form.GetString();
            Console.WriteLine();
        }

        public void ChangeTariff(bool printNew = false)
        {
            var enumValues = Enum.GetNames(typeof(Tariff))
                .OrderBy(element => (int)Enum.Parse(typeof(Tariff), element));
            var menu = new LiteMenu
            {
                Name = $"{GetNamePrefix(printNew)}tariff"
            };
            foreach (var value in enumValues)
                menu.Items.Add(
                    new MenuItem { 
                        Text = value, 
                        Action = () => _customer.Tariff = (Tariff)Enum.Parse(typeof(Tariff), value) 
                    }
                );
            menu.Print();
            Console.WriteLine();
        }
    }
}
