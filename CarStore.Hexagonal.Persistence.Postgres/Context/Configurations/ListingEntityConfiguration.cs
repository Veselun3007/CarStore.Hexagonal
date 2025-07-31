using CarStore.Hexagonal.Persistence.Postgres.Context.Configurations.Base;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Hexagonal.Persistence.Postgres.Context.Configurations
{
    internal class ListingEntityConfiguration : BaseEntityConfiguration<ListingEntity>
    {
        public ListingEntityConfiguration() : base("listing_id") { }
        
        protected override void ConfigureEntity(EntityTypeBuilder<ListingEntity> builder)
        {
            builder.ToTable("listings");
           
            builder.Property(l => l.CarId).IsRequired().HasMaxLength(36).IsFixedLength().HasColumnName("car_id");
            builder.Property(l => l.DealerId).IsRequired().HasMaxLength(36).IsFixedLength().HasColumnName("dealer_id");
            builder.Property(l => l.ListedPrice).HasColumnType("decimal(18,2)").IsRequired().HasColumnName("listed_price");
            builder.Property(l => l.CreatedAt).HasColumnType("timestamp with time zone").IsRequired().HasColumnName("created_at");
            builder.Property(l => l.Status).IsRequired().HasColumnName("status");
            builder.Property(l => l.Description).HasMaxLength(512).HasColumnName("description");

            builder.HasOne(l => l.Car)
                .WithOne(c => c.Listing)
                .HasForeignKey<ListingEntity>(l => l.CarId)
                .OnDelete(DeleteBehavior.Cascade).HasConstraintName("fk_car_listing");

            builder.HasOne(l => l.Dealer)
                .WithMany(u => u.Listings)
                .HasForeignKey(l => l.DealerId)
                .OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_listing_dealer");
        }
    }
}
