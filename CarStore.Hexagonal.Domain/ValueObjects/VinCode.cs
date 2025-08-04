using CarStore.Hexagonal.Domain.Base;
using System.Text.RegularExpressions;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly partial struct VinCode : IValueObject
    {
        public string Value { get; }

        public VinCode(string vin)
        {
            Value = vin?.ToUpperInvariant();

            Validate();
        }

        public void Validate()
        {
            if(string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentNullException("VIN code must not be empty.");
            }

            if(!ValidateVin().IsMatch(Value))
            {
                throw new ArgumentException("VIN code must be exactly 17 characters, using uppercase letters (excluding I, O, Q) and digits.");
            }
        }

        [GeneratedRegex("^[A-HJ-NPR-Z0-9]{17}$")]
        private static partial Regex ValidateVin();
    }
}
