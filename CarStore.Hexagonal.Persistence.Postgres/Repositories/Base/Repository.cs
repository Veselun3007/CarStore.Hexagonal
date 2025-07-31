using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Persistence.Postgres.Context;
using CarStore.Hexagonal.Persistence.Postgres.Entities.Base;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Hexagonal.Persistence.Postgres.Repositories.Base
{
    public abstract class Repository<TDomain, TEntity, TKey> : IRepository<TDomain, TKey>
        where TEntity : BaseEntity<TKey>
    {
        protected readonly CarStoreContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IEntityMapper<TDomain, TEntity> _mapper;

        public Repository(CarStoreContext dbContext, IEntityMapper<TDomain, TEntity> mapper)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _mapper = mapper;
        }

        public virtual async Task<TDomain> AddAsync(TDomain domain)
        {
            var entity = _mapper.ToEntity(domain);
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.ToDomain(entity);
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if(entity is not null)
            {
                _dbSet.Remove(entity);
            }
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TDomain>?> GetAllAsync()
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            var list = await query.ToListAsync();
            return list.Select(_mapper.ToDomain);
        }

        public virtual async Task<TDomain?> FindByIdAsync(TKey id)
        {
            var query = _dbSet.AsQueryable();
            var entity = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return _mapper.ToDomain(entity);
        }

        public virtual async Task<TDomain?> UpdateAsync(TKey id, TDomain domain)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            var entity = _mapper.ToEntity(domain);
            entity.Id = id;
            if(existingEntity is not null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.ToDomain(entity);
        }
    }
}
