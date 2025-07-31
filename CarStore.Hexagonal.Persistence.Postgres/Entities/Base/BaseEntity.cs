namespace CarStore.Hexagonal.Persistence.Postgres.Entities.Base
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
