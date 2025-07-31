using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Context;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using CarStore.Hexagonal.Persistence.Postgres.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Hexagonal.Persistence.Postgres.Repositories
{
    public class CarRepository : Repository<Car, CarEntity, string>
    {
        public CarRepository(CarStoreContext dbContext, IEntityMapper<Car, CarEntity> mapper) : base(dbContext, mapper) { }
    }

    public class UserRepository : Repository<User, UserEntity, string>
    {
        public UserRepository(CarStoreContext dbContext, IEntityMapper<User, UserEntity> mapper) : base(dbContext, mapper) { }
    }

    public class ListingRepository : Repository<Listing, ListingEntity, string>
    {
        public ListingRepository(CarStoreContext dbContext, IEntityMapper<Listing, ListingEntity> mapper) : base(dbContext, mapper) { }

        public override async Task<IEnumerable<Listing>?> GetAllAsync()
        {
            IQueryable<ListingEntity> query = _dbSet.AsNoTracking();
            var list = await query
                .Include(l => l.TestDrives)
                .Include(l => l.Offers)
                .ToListAsync();
            
            return list.Select(_mapper.ToDomain);
        }

        public override async Task<Listing?> FindByIdAsync(string id)
        {
            var query = _dbSet.AsQueryable();
            var entity = await query
                .Include(l => l.TestDrives)
                .Include(l => l.Offers)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return _mapper.ToDomain(entity);
        }
    }
}
