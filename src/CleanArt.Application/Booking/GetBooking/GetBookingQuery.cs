using CleanArt.Application.Abstractions.Messaging.Query;

namespace CleanArt.Application.Booking.GetBooking
{
    public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
}
