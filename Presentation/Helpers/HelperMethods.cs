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

        internal static string GetHeader(string subtype)
        {
            return $"22. Rental calculator: Demo | {subtype}{Environment.NewLine}" +
                    "Nikita Chernikov, IS-02";
        }
    }
}
