using CarStore.Hexagonal.Domain.Base;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly struct CarDescription : IValueObject
    {
        public string Value { get; }

        public CarDescription(string description)
        {          
            Value = description;

            Validate();
        }

        public void Validate()
        {
            if(string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentNullException("Description cannot be empty");
            }

            if(Value.Length < 50 || Value.Length > 512)
            {
                throw new ArgumentException("Description must contain between 50 and 512 characters.");
            }
        }
    }
}
