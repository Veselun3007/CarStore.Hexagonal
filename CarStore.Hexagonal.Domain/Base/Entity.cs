namespace CarStore.Hexagonal.Domain.Base
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
