using CleanArt.Application.Abstractions.Messaging.Query;
using CleanArt.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Booking.GetBooking
{
    internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        public Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
