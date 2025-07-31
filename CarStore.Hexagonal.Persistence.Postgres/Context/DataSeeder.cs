using Microsoft.EntityFrameworkCore;
using CarStore.Hexagonal.Persistence.Postgres.Entities;

namespace CarStore.Hexagonal.Persistence.Postgres.Context
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            static DateTime Utc(string iso8601) => DateTime.SpecifyKind(DateTime.Parse(iso8601), DateTimeKind.Utc);

            var user1Id = "00000000-0000-0000-0000-000000000001";
            var user2Id = "00000000-0000-0000-0000-000000000002";

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = user1Id,
                    FullName = "Alice Johnson",
                    Email = "alice@example.com"
                },
                new UserEntity
                {
                    Id = user2Id,
                    FullName = "Bob Smith",
                    Email = "bob.smith@example.com"
                }
            );

            var car1Id = "00000000-0000-0000-0000-000000000011";
            var car2Id = "00000000-0000-0000-0000-000000000012";

            modelBuilder.Entity<CarEntity>().HasData(
                new CarEntity
                {
                    Id = car1Id,
                    Make = "Toyota",
                    Model = "Corolla",
                    Vin = "JH4KA8260MC000001",
                    Price = 15000.00m
                },
                new CarEntity
                {
                    Id = car2Id,
                    Make = "Honda",
                    Model = "Civic",
                    Vin = "JH4KA8260MC000002",
                    Price = 15500.00m
                }
            );

            var listing1Id = "00000000-0000-0000-0000-000000000021";
            var listing2Id = "00000000-0000-0000-0000-000000000022";

            modelBuilder.Entity<ListingEntity>().HasData(
                new ListingEntity
                {
                    Id = listing1Id,
                    CarId = car1Id,
                    DealerId = user1Id,
                    ListedPrice = 16000.00m,
                    CreatedAt = Utc("2025-01-01T10:00:00Z"),
                    Status = 0,
                    Description = "Vehicle in excellent condition, meticulously maintained by a single owner, no issues."
                },
                new ListingEntity
                {
                    Id = listing2Id,
                    CarId = car2Id,
                    DealerId = user2Id,
                    ListedPrice = 16500.00m,
                    CreatedAt = Utc("2025-01-02T11:00:00Z"),
                    Status = 0,
                    Description = "Exceptionally low mileage, runs and looks like new, barely used and carefully preserved."
                }
            );

            var offer1Id = "00000000-0000-0000-0000-000000000031";
            var offer2Id = "00000000-0000-0000-0000-000000000032";

            modelBuilder.Entity<OfferEntity>().HasData(
                new OfferEntity
                {
                    Id = offer1Id,
                    ListingId = listing1Id,
                    CustomerId = user2Id,
                    Price = 15800.00m,
                    CreatedAt = Utc("2025-01-03T08:00:00Z"),
                    State = 0
                },
                new OfferEntity
                {
                    Id = offer2Id,
                    ListingId = listing2Id,
                    CustomerId = user1Id,
                    Price = 16200.00m,
                    CreatedAt = Utc("2025-01-04T09:00:00Z"),
                    State = 0
                }
            );

            var testDrive1Id = "00000000-0000-0000-0000-000000000041";
            var testDrive2Id = "00000000-0000-0000-0000-000000000042";

            modelBuilder.Entity<TestDriveRequestEntity>().HasData(
                new TestDriveRequestEntity
                {
                    Id = testDrive1Id,
                    ListingId = listing1Id,
                    CustomerId = user2Id,
                    CreatedAt = Utc("2025-01-05T12:00:00Z"),
                    RequestedDate = Utc("2025-01-10T10:00:00Z"),
                    IsApproved = false
                },
                new TestDriveRequestEntity
                {
                    Id = testDrive2Id,
                    ListingId = listing2Id,
                    CustomerId = user1Id,
                    CreatedAt = Utc("2025-01-06T13:00:00Z"),
                    RequestedDate = Utc("2025-01-11T11:00:00Z"),
                    IsApproved = false
                }
            );
        }
    }
}
