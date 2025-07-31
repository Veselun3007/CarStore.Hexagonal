using CarStore.Hexagonal.Domain.Enums;

namespace CarStore.Hexagonal.Domain.Common
{
    public static class CurrencyConverter
    {
        private static readonly Dictionary<(Currency from, Currency to), decimal> _rates = new()
        {
            { (Currency.USD, Currency.UAH), 40.00m },
            { (Currency.USD, Currency.EUR), 0.93m },
            { (Currency.UAH, Currency.USD), 1 / 40.00m },
            { (Currency.EUR, Currency.USD), 1 / 0.93m },
            { (Currency.EUR, Currency.UAH), 40.00m / 0.93m },
            { (Currency.UAH, Currency.EUR), 0.93m / 40.00m }
        };

        public static decimal GetRate(Currency from, Currency to)
        {
            if(from == to)
            {
                return 1.0m;
            }

            return _rates.TryGetValue((from, to), out var rate)
                ? rate
                : throw new NotSupportedException($"No conversion rate for {from} → {to}");
        }
    }
}
