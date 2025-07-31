using CarStore.Hexagonal.Domain.Base;
using System.Text.RegularExpressions;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly partial struct VinCode : IValueObject<string>
    {
        public string Value { get; }

        public VinCode(string vin)
        {
            if(string.IsNullOrWhiteSpace(vin))
            {
                throw new ArgumentNullException(nameof(vin));
            }

            var normalized = vin.ToUpperInvariant();

            if(!Validate(normalized))
            {
                throw new ArgumentException("Invalid VIN code format.");
            }

            Value = normalized;
        }

        public readonly bool Validate(string code) => ValidateVin().IsMatch(code);

        [GeneratedRegex("^[A-HJ-NPR-Z0-9]{17}$")]
        private static partial Regex ValidateVin();
    }
}
