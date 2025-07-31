using CarStore.Hexagonal.Domain.Base;
using CarStore.Hexagonal.Domain.Enums;
using CarStore.Hexagonal.Domain.ValueObjects;

namespace CarStore.Hexagonal.Domain.Entities
{
    public class Listing : AggregateRoot<string>
    {
        public string CarId { get; private set; }
        public string DealerId { get; private set; }
        public Money ListedPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ListingStatus Status { get; private set; }
        public CarDescription Description { get; private set; }

        private readonly List<Offer> _offers = [];
        public IReadOnlyCollection<Offer> Offers => _offers;

        private readonly List<TestDriveRequest> _testDrives = [];
        public IReadOnlyCollection<TestDriveRequest> TestDriveRequests => _testDrives;

        public Listing(string carId, string dealerId, Money listedPrice, CarDescription description)
        {
            Id = Guid.NewGuid().ToString();
            CarId = carId;
            DealerId = dealerId;
            ListedPrice = listedPrice;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            Status = ListingStatus.Draft;
        }

        public Listing(string id, string carId, string dealerId, Money listedPrice, CarDescription description)
        {
            Id = id;
            CarId = carId;
            DealerId = dealerId;
            ListedPrice = listedPrice;
            Description = description;
        }

        internal Listing(string id, string carId, string dealerId,
            Money listedPrice, CarDescription description, DateTime createdAt, ListingStatus status,
            IReadOnlyCollection<Offer> offers, IReadOnlyCollection<TestDriveRequest> testDrives)
        {
            Id = id;
            CarId = carId;
            DealerId = dealerId;
            ListedPrice = listedPrice;
            Description = description;
            CreatedAt = createdAt;
            Status = status;

            _offers.AddRange(offers);
            _testDrives.AddRange(testDrives);
        }

        public void Post()
        {
            if(Status != ListingStatus.Draft)
            {
                throw new InvalidOperationException("Only draft listings can be posted.");
            }

            Status = ListingStatus.Posted;
        }

        public void Cancel()
        {
            if(Status != ListingStatus.Posted)
            {
                throw new InvalidOperationException("Only posted listings can be cancelled.");
            }

            Status = ListingStatus.Cancelled;
        }

        public void Reopen()
        {
            if(Status != ListingStatus.Cancelled)
            {
                throw new InvalidOperationException("Only cancelled listings can be reopened.");
            }

            Status = ListingStatus.Posted;
        }

        public void AddOffer(Offer offer)
        {
            if(Status != ListingStatus.Posted)
            {
                throw new InvalidOperationException("Offers can only be added to posted listings.");
            }

            if(_offers.Any(x => x.CustomerId == offer.CustomerId))
            {
                throw new InvalidOperationException("Buyer has already made an offer.");
            }

            _offers.Add(offer);
        }

        public void RemoveOffer(string offerId)
        {
            if(Status != ListingStatus.Posted)
            {
                throw new InvalidOperationException("Offers can only be removed from posted listings.");
            }

            var offer = _offers.FirstOrDefault(x => x.Id == offerId) ?? 
                throw new KeyNotFoundException("Offer not found");
            
            _offers.Remove(offer);
        }

        public void RequestTestDrive(TestDriveRequest request)
        {
            if(Status != ListingStatus.Posted)
            {
                throw new InvalidOperationException("Test drive can only be requested for posted listings.");
            }

            if(request.RequestedDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Test drive date cannot be in the past.");
            }

            if(_testDrives.Any(x => x.CustomerId == request.CustomerId && x.RequestedDate.Date == request.RequestedDate.Date))
            {
                throw new InvalidOperationException("Test drive for this date already requested.");
            }

            _testDrives.Add(request);
        }

        public void RecallTestDrive(string testDriveRequestId)
        {
            if(Status != ListingStatus.Posted)
            {
                throw new InvalidOperationException("Test drive can only be recalled for posted listings.");
            }

            var testDrives = _testDrives.FirstOrDefault(x => x.Id == testDriveRequestId) ??
                throw new KeyNotFoundException("Test drive not found");

            _testDrives.Remove(testDrives);
        }

        public void AcceptOffer(string customerId)
        {
            if(Status != ListingStatus.Posted)
            {
                throw new InvalidOperationException("Only posted listings can accept offers.");
            }

            var offer = _offers.FirstOrDefault(x => x.CustomerId == customerId) ?? 
                throw new InvalidOperationException("Offer from this customer not found.");

            offer.Accept();

            foreach(var o in _offers)
            {
                if(o.CustomerId != customerId && o.Status == OfferStatus.Pending)
                {
                    o.Decline();
                }
            }

            Apply(new OfferAccepted
            {
                ListingId = Id,
                OfferId = offer.Id,
                CustomerId = customerId,
                AcceptedAt = DateTime.UtcNow
            });
        }


        protected override void When(object @event)
        {
            switch(@event)
            {
                case OfferAccepted:
                    Status = ListingStatus.Completed;
                    break;

                // Additional domain events should be handled here as needed
            }
        }
    }
}
