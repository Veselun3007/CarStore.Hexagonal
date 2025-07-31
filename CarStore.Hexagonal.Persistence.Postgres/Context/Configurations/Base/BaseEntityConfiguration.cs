using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CarStore.Hexagonal.Persistence.Postgres.Entities.Base;

namespace CarStore.Hexagonal.Persistence.Postgres.Context.Configurations.Base
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<string>
    {
        private readonly string _identifierName;

        protected BaseEntityConfiguration(string identifierName)
        {
            _identifierName = identifierName;
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureId(builder);
            ConfigureEntity(builder);
        }

        private void ConfigureId(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(36)
                .IsFixedLength()
                .ValueGeneratedNever()
                .HasColumnName(_identifierName);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
