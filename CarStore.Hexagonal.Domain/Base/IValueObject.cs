namespace CarStore.Hexagonal.Domain.Base
{
    public interface IValueObject<TProperty>
    {
        bool Validate(TProperty value);
    }
}
