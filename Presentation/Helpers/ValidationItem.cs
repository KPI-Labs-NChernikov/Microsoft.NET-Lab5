namespace Presentation.Helpers
{
    public class ValidationItem
    {
        public Func<string?, bool>? Validate { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
