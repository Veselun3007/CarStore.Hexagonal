using CarStore.Hexagonal.Application.Features.Cars.Commands.AddCar;
using CarStore.Hexagonal.Application.Features.Cars.Commands.DeleteCar;
using CarStore.Hexagonal.Application.Features.Cars.Commands.UpdateCar;
using CarStore.Hexagonal.Application.Features.Listings.Commands.AddListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.CancelListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.PostListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.ReopenListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.UpdateListing;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AcceptOffer;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AddOffer;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeclineOffer;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeleteOffer;
using CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.AddTestDriveRequest;
using CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.ApproveTestDrive;
using CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.DeleteTestDriveRequest;
using CarStore.Hexagonal.Application.Features.Users.Commands.AddUser;
using CarStore.Hexagonal.Application.Features.Users.Commands.DeleteUser;
using CarStore.Hexagonal.Application.Features.Users.Commands.UpdateUser;

namespace CarStore.Hexagonal.Presentation.WebApi.SwaggerTests
{
    public class TestDataFactory
    {
        #region === User Command ===
        public static AddUserCommand UserAdd()
        {
            return new AddUserCommand()
            {
                FullName = "John Doe",
                Email = "john.doe@example.com"
            };
        }

        public static UpdateUserCommand UserUpdate()
        {
            return new UpdateUserCommand()
            {
                Id = "00000000-0000-0000-0000-000000000001",
                FullName = "John Van Doe",
                Email = "john.doe@example.com"
            };
        }

        public static DeleteUserCommand UserDelete()
        {
            return new DeleteUserCommand()
            {
                UserId = "00000000-0000-0000-0000-000000000002"
            };
        }
        #endregion

        #region === Car Command ===
        public static AddCarCommand CarAdd()
        {
            return new AddCarCommand()
            {
                Make = "Toyota",
                Model = "Corolla",
                Vin = "1HGCM82633A004352",
                Price = 18999.99m
            };
        }

        public static UpdateCarCommand CarUpdate()
        {
            return new UpdateCarCommand()
            {
                CarId = "00000000-0000-0000-0000-000000000012",
                Make = "Toyota",
                Model = "Corolla SE",
                Vin = "1HGCM82633A004352",
                Price = 19999.99m
            };
        }

        public static DeleteCarCommand CarDelete()
        {
            return new DeleteCarCommand()
            {
                CarId = "00000000-0000-0000-0000-000000000011"
            };
        }
        #endregion

        #region === Listing Command ===
        public static AddListingCommand ListingAdd()
        {
            return new AddListingCommand
            {
                CarId = "First, create a new car entity, then use the returned ID for further configuration.",
                DealerId = "00000000-0000-0000-0000-000000000002",
                ListedPrice = 16500.00m,
                Description = "Exceptionally low mileage, runs and looks like new. Barely used and carefully preserved by one owner.",
                Discount = 10.00m
            };
        }

        public static UpdateListingCommand ListingUpdate()
        {
            return new UpdateListingCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000022",
                CarId = "00000000-0000-0000-0000-000000000012",
                DealerId = "00000000-0000-0000-0000-000000000002",
                ListedPrice = 16200.00m,
                Description = "Updated listing. Vehicle inspected, certified by dealer. Ready for delivery. Clean interior and exterior, no dents.",
                Discount = 5.00m
            };
        }

        public static PostListingCommand ListingPost()
        {
            return new PostListingCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000022"
            };
        }

        public static CancelListingCommand ListingCancel()
        {
            return new CancelListingCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000022"
            };
        }

        public static ReopenListingCommand ListingReopen()
        {
            return new ReopenListingCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000022"
            };
        }

        public static AddOfferCommand ListingAddOffer()
        {
            return new()
            {
                ListingId = "00000000-0000-0000-0000-000000000021",
                CustomerId = "00000000-0000-0000-0000-000000000002",
                Price = 15800.00m,
                Discount = 3.00m
            };
        }

        public static AcceptOfferCommand ListingAcceptOffer()
        {
            return new AcceptOfferCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000021",
                CustomerId = "00000000-0000-0000-0000-000000000002"
            };
        }

        public static DeclineOfferCommand ListingDeclineOffer()
        {
            return new DeclineOfferCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000021",
                CustomerId = "00000000-0000-0000-0000-000000000002"
            };
        }

        public static DeleteOfferCommand ListingDeleteOffer()
        {
            return new DeleteOfferCommand
            {
                OfferId = "00000000-0000-0000-0000-000000000031",
                ListingId = "00000000-0000-0000-0000-000000000021"
            };
        }

        public static AddTestDriveRequestCommand ListingRequestTestDrive()
        {
            return new AddTestDriveRequestCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000021",
                CustomerId = "00000000-0000-0000-0000-000000000002",
                RequestedDate = DateTime.UtcNow.AddDays(3)
            };
        }

        public static ApproveTestDriveCommand ListingApproveTestDrive()
        {
            return new ApproveTestDriveCommand
            {
                ListingId = "00000000-0000-0000-0000-000000000021",
                CustomerId = "00000000-0000-0000-0000-000000000002"
            };
        }

        public static DeleteTestDriveRequestCommand ListingDeleteTestDrive()
        {
            return new DeleteTestDriveRequestCommand
            {
                TestDriveRequestId = "00000000-0000-0000-0000-000000000041",
                ListingId = "00000000-0000-0000-0000-000000000021"
            };
        }
        #endregion
    }
}
