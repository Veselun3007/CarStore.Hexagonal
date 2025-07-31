namespace CarStore.Hexagonal.Application.Interfaces
{
    public interface IRepository<TDomain, TKey>
    {
        Task<TDomain> AddAsync(TDomain entity);

        Task DeleteAsync(TKey id);

        Task<TDomain?> UpdateAsync(TKey id, TDomain entity);

        Task<IEnumerable<TDomain>?> GetAllAsync();

        Task<TDomain?> FindByIdAsync(TKey id);
    }
}
