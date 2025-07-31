using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.ReopenListing
{
    public class ReopenListingCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
    }
}
