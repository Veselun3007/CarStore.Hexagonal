using CarStore.Hexagonal.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly struct UserEmail : IValueObject
    {
        public string Value { get; }

        public UserEmail(string email)
        {
            Value = email;

            Validate();
        }

        public void Validate()
        {
            if(string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentNullException("Email cannot be empty");
            }

            if(!new EmailAddressAttribute().IsValid(Value))
            {
                throw new ArgumentException("Email address format is invalid.");
            }
        }
    }
}
