using CleanArt.Domain.Apartments;

namespace CleanArt.Domain.Bookings
{
    public interface IBookingRepository
    {
        Task<bool> IsOverLappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default);
        void Add(Booking booking);
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
