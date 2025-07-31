using CarStore.Hexagonal.Domain.Base;
using System.Text.RegularExpressions;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly partial struct UserFullName : IValueObject<string>
    {
        public string Value { get; }

        public UserFullName(string fullName)
        {
            if(string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException(nameof(fullName));
            }

            if(!Validate(fullName))
            {
                throw new ArgumentException("Invalid full name format.");
            }

            Value = fullName;
        }

        public readonly bool Validate(string fullName) => ValidateFullName().IsMatch(fullName);

        [GeneratedRegex("^[A-Z][a-z]*(\\s[A-Z][a-z]*)+$")]
        private static partial Regex ValidateFullName();
    }
}
