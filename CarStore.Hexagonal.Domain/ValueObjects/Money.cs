using CarStore.Hexagonal.Domain.Base;
using CarStore.Hexagonal.Domain.Common;
using CarStore.Hexagonal.Domain.Enums;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly struct Money : IValueObject
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
            Amount = amount;
            Currency = currency;
            DiscountPercent = appliedDiscountPercent;

            Validate();
        }

        public void Validate()
        {
            if(Amount < 0)
            {
                throw new ArgumentException("Amount must be non-negative.");
            }

            if(DiscountPercent is < 0 or > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100.");
            }
        }

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

            return new Money(Amount, Currency, percent);
        }

        public Money ConvertTo(Currency targetCurrency)
        {
            if(Currency == targetCurrency)
            {
                return this;
            }

            var rate = CurrencyConverter.GetRate(Currency, targetCurrency);
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
