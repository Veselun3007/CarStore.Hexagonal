using CarStore.Hexagonal.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly struct UserEmail : IValueObject<string>
    {
        public string Value { get; }

        public UserEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            if(!Validate(email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            Value = email;
        }

        public bool Validate(string email) => new EmailAddressAttribute().IsValid(email);
    }
}
