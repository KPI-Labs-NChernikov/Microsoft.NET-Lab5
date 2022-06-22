using Presentation.Interfaces;

namespace Presentation.Stringifiers
{
    public class TimeSpanStringifier : IStringifier
    {
        private readonly TimeSpan _span;

        public TimeSpanStringifier(TimeSpan span)
        {
            _span = span;
        }

        public string Stringify()
        {
            return $"{_span.Days} day{GetPostfix(_span.Days)} {_span.Hours} hour{GetPostfix(_span.Hours)}";
        }

        private static string GetPostfix(int value) => value == 1 ? string.Empty : "s";
    }
}
