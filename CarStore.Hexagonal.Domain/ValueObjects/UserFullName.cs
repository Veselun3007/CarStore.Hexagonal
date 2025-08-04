using CarStore.Hexagonal.Domain.Base;
using System.Text.RegularExpressions;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly partial struct UserFullName : IValueObject
    {
        public string Value { get; }

        public UserFullName(string fullName)
        {
            Value = fullName;

            Validate();
        }

        public void Validate()
        {
            if(string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentNullException("Full name must not be empty.");
            }

            if(!ValidateFullName().IsMatch(Value))
            {
                throw new ArgumentException("Full name must contain at least two capitalized words separated by spaces (e.g., 'John Doe').");
            }
        }

        [GeneratedRegex("^[A-Z][a-z]*(\\s[A-Z][a-z]*)+$")]
        private static partial Regex ValidateFullName();
    }
}
