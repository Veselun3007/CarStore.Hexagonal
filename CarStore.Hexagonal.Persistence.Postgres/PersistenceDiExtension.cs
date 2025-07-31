using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Context;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Mapping;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using CarStore.Hexagonal.Persistence.Postgres.Options;
using CarStore.Hexagonal.Persistence.Postgres.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarStore.Hexagonal.Persistence.Postgres
{
    public static class PersistenceDiExtension
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var dbOptions = builder.Configuration.GetSection(nameof(DbOptions)).Get<DbOptions>() ?? new DbOptions();
            builder.Services.AddDbContext<CarStoreContext>((options) =>
            {
                options.UseNpgsql(dbOptions.ConnectionString);
            });
            builder.Services.AddSingleton<IEntityMapper<User, UserEntity>, UserMapper>();
            builder.Services.AddSingleton<IEntityMapper<Car, CarEntity>, CarMapper>();
            builder.Services.AddSingleton<IEntityMapper<Listing, ListingEntity>, ListingMapper>();
            builder.Services.AddSingleton<IEntityMapper<Offer, OfferEntity>, OfferMapper>();
            builder.Services.AddSingleton<IEntityMapper<TestDriveRequest, TestDriveRequestEntity>, TestDriveRequestMapper>();

            builder.Services.AddScoped<IRepository<Listing, string>, ListingRepository>();
            builder.Services.AddScoped<IRepository<User, string>, UserRepository>();
            builder.Services.AddScoped<IRepository<Car, string>, CarRepository>();
        }
    }
}

