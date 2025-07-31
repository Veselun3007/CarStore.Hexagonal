using CarStore.Hexagonal.Persistence.Postgres.Context.Configurations.Base;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Hexagonal.Persistence.Postgres.Context.Configurations
{
    internal class CarEntityConfiguration : BaseEntityConfiguration<CarEntity>
    {
        public CarEntityConfiguration() : base("car_id") { }

        protected override void ConfigureEntity(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("cars");

            builder.HasIndex(c => c.Vin).IsUnique();

            builder.Property(c => c.Make).IsRequired().HasMaxLength(100).HasColumnName("make");
            builder.Property(c => c.Model).IsRequired().HasMaxLength(100).HasColumnName("model");
            builder.Property(c => c.Vin).IsRequired().HasMaxLength(17).HasColumnName("vin");
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)").IsRequired().HasColumnName("price");
        }
    }
}
