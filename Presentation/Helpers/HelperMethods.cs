namespace Presentation.Helpers
{
    public static class HelperMethods
    {
        public static void Continue()
        {
            Console.WriteLine("Press enter co continue");
            Console.ReadLine();
        }

        public static void PrintHeader(string header)
        {
            Console.WriteLine($"{header}{Environment.NewLine}");
        }

        public static void PrintErrorMessage(string? excMessage)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            excMessage = string.IsNullOrEmpty(excMessage) ? "Ooops, unknown error occured..."
                : $"An error occured: {excMessage}";
            Console.WriteLine(excMessage);
            Console.ForegroundColor = initialColor;
        }

        public static string? Search(string toFind)
        {
            Console.WriteLine($"Please, enter the {toFind}: ");
            return Console.ReadLine();
        }

        internal static string GetHeader(string subtype)
        {
            return $"22. Rental calculator: Demo | {subtype}{Environment.NewLine}" +
                    "Nikita Chernikov, IS-02";
        }
    }
}
