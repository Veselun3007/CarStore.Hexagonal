namespace CarStore.Hexagonal.Persistence.Postgres.Mapping.Base
{
    public interface IEntityMapper<TDomain, TEntity>
    {
        TDomain ToDomain(TEntity entity);
        TEntity ToEntity(TDomain domain);
    }
}
