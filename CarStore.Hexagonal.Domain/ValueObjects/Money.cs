using CarStore.Hexagonal.Domain.Base;
using CarStore.Hexagonal.Domain.Common;
using CarStore.Hexagonal.Domain.Enums;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly struct Money : IValueObject<decimal>
    {
        public decimal Amount { get; }
        public Currency Currency { get; }
        public decimal? DiscountPercent { get; }
        public decimal FinalAmount
        {
            get
            {
                return DiscountPercent is null
                ? Amount
                : decimal.Round(Amount * (1 - (decimal)DiscountPercent / 100m), 2, MidpointRounding.AwayFromZero);
            }
        }

        public Money(decimal amount, Currency currency, decimal? appliedDiscountPercent = null)
        {
            if(!Validate(amount))
            {
                throw new ArgumentException("Amount must be non-negative.");
            }

            if(appliedDiscountPercent is < 0 or > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100.");
            }

            Amount = amount;
            Currency = currency;
            DiscountPercent = appliedDiscountPercent;
        }

        public readonly bool Validate(decimal value) => value >= 0;

        public Money ApplyDiscount(decimal percent)
        {
            if(percent is < 0 or > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100.");
            }

            if(percent == 0)
            {
                return this;
            }

            var discounted = Amount * (1 - percent / 100m);
            var rounded = decimal.Round(discounted, 2, MidpointRounding.AwayFromZero);
            return new Money(rounded, Currency, percent);
        }

        public Money ConvertTo(Currency targetCurrency, Currency baseCurrency = Currency.USD)
        {
            if(Currency == targetCurrency)
            {
                return this;
            }

            var rate = CurrencyConverter.GetRate(baseCurrency, targetCurrency);
            var converted = Amount * rate;
            return new Money(decimal.Round(converted, 2), targetCurrency, DiscountPercent);
        }

        public override bool Equals(object? obj) =>
            obj is Money other &&
            Amount == other.Amount &&
            Currency == other.Currency &&
            DiscountPercent == other.DiscountPercent;

        public override int GetHashCode() => HashCode.Combine(Amount, Currency, DiscountPercent);

        public static bool operator ==(Money left, Money right) => left.Equals(right);
        public static bool operator !=(Money left, Money right) => !(left == right);
    }
}
