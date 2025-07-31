using CarStore.Hexagonal.Persistence.Postgres.Context.Configurations.Base;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Hexagonal.Persistence.Postgres.Context.Configurations
{
    public class TestDriveRequestEntityConfiguration : BaseEntityConfiguration<TestDriveRequestEntity>
    {
        public TestDriveRequestEntityConfiguration() : base("test_drive_requests_id") { }

        protected override void ConfigureEntity(EntityTypeBuilder<TestDriveRequestEntity> builder)
        {
            builder.ToTable("test_drive_requests");

            builder.HasIndex(o => new { o.CustomerId, o.CreatedAt }).HasDatabaseName("customers_request_descending").IsDescending().IsUnique();

            builder.Property(t => t.ListingId).IsRequired().HasMaxLength(36).IsFixedLength().HasColumnName("listing_id");
            builder.Property(t => t.CustomerId).IsRequired().HasMaxLength(36).IsFixedLength().HasColumnName("customer_id");
            builder.Property(t => t.CreatedAt).HasColumnType("timestamp with time zone").IsRequired().HasColumnName("created_at");
            builder.Property(t => t.RequestedDate).HasColumnType("timestamp with time zone").IsRequired().HasColumnName("requested_date");
            builder.Property(t => t.IsApproved).IsRequired().HasColumnName("is_approved");

            builder.HasOne(t => t.Listing)
                .WithMany(l => l.TestDrives)
                .HasForeignKey(t => t.ListingId)
                .OnDelete(DeleteBehavior.Cascade).HasConstraintName("fk_test_drive_listing");

            builder.HasOne(t => t.Customer)
                .WithMany(u => u.TestDriveRequests)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_test_drive_customer");
        }
    }
}
