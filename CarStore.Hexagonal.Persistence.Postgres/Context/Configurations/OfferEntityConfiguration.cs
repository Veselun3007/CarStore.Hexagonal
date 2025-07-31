using CarStore.Hexagonal.Persistence.Postgres.Context.Configurations.Base;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Hexagonal.Persistence.Postgres.Context.Configurations
{
    public class OfferEntityConfiguration : BaseEntityConfiguration<OfferEntity>
    {
        public OfferEntityConfiguration() : base("offer_id") { }

        protected override void ConfigureEntity(EntityTypeBuilder<OfferEntity> builder)
        {
            builder.ToTable("offers");

            builder.HasIndex(o => new { o.CustomerId, o.CreatedAt }).HasDatabaseName("customers_offer_descending").IsDescending().IsUnique();

            builder.Property(o => o.ListingId).IsRequired().HasMaxLength(36).IsFixedLength().HasColumnName("listing_id");
            builder.Property(o => o.CustomerId).IsRequired().HasMaxLength(36).IsFixedLength().HasColumnName("customer_id");
            builder.Property(o => o.Price).HasColumnType("decimal(18,2)").IsRequired().HasColumnName("price");
            builder.Property(o => o.CreatedAt).HasColumnType("timestamp with time zone").IsRequired().HasColumnName("created_at");
            builder.Property(o => o.State).IsRequired().HasColumnName("state");

            builder.HasOne(o => o.Listing)
                .WithMany(l => l.Offers)
                .HasForeignKey(o => o.ListingId)
                .OnDelete(DeleteBehavior.Cascade).HasConstraintName("fk_offer_listing");

            builder.HasOne(o => o.Customer)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_offer_customer");
        }
    }
}
