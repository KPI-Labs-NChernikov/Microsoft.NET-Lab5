namespace Data.Other
{
    public readonly struct CoefficientContainer
    {
        public CoefficientContainer()
        {        }

        public decimal Penalty { get; init; } = 0.1m;

        public decimal Sale { get; init; } = decimal.Zero;
    }
}
