using CarStore.Hexagonal.Persistence.Postgres.Context.Configurations.Base;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Hexagonal.Persistence.Postgres.Context.Configurations
{
    public class UserEntityConfiguration : BaseEntityConfiguration<UserEntity>
    {
        public UserEntityConfiguration() : base("user_id") { }

        protected override void ConfigureEntity(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.FullName).IsRequired().HasColumnName("full_name");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200).HasColumnName("email");
        }
    }
}
