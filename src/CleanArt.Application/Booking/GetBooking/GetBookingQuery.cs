using CleanArt.Application.Abstractions.Cache;
using CleanArt.Application.Abstractions.Messaging.Query;

namespace CleanArt.Application.Booking.GetBooking
{
    public sealed record GetBookingQuery(Guid BookingId) : ICachedQuery<BookingResponse>
    {
        public string CacheKey => $"booking-{BookingId}";

        public TimeSpan? Expiration => null;
    }
}
