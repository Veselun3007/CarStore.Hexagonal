using CarStore.Hexagonal.Persistence.Postgres.Context.Configurations;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Hexagonal.Persistence.Postgres.Context
{
    public class CarStoreContext : DbContext
    {
        public CarStoreContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<CarEntity> Cars { get; set; }
        public virtual DbSet<ListingEntity> Listing { get; set; }
        public virtual DbSet<OfferEntity> Offer { get; set; }
        public virtual DbSet<TestDriveRequestEntity> TestDriveRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserEntityConfiguration().Configure(modelBuilder.Entity<UserEntity>());
            new CarEntityConfiguration().Configure(modelBuilder.Entity<CarEntity>());
            new ListingEntityConfiguration().Configure(modelBuilder.Entity<ListingEntity>());
            new OfferEntityConfiguration().Configure(modelBuilder.Entity<OfferEntity>());
            new TestDriveRequestEntityConfiguration().Configure(modelBuilder.Entity<TestDriveRequestEntity>());
            DataSeeder.Seed(modelBuilder);
        }
    }
}
