using CarStore.Hexagonal.Domain.Base;

namespace CarStore.Hexagonal.Domain.ValueObjects
{
    public readonly struct CarDescription : IValueObject<string>
    {
        public string Value { get; }

        public CarDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if(!Validate(description))
            {
                throw new ArgumentException("Invalid description format.");
            }

            Value = description;
        }

        public readonly bool Validate(string description) => description.Length > 50 && description.Length < 512;
    }
}
