using CleanArt.Domain.Apartments;
using CleanArt.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Infrastructure.Repositories
{
    internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private static readonly BookingStatus[] ActiveBookingStatuses =
        {
            BookingStatus.Reserved,
            BookingStatus.Confirmed,
            BookingStatus.Completed
        };

        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> IsOverlappingAsync(
            Apartment apartment,
            DateRange duration,
            CancellationToken cancellationToken=default)
        {
            return await _context
                .Set<Booking>()
                .AnyAsync(
                    booking=>
                    booking.ApartmentId==apartment.Id &&
                    booking.Duration.Start<=duration.End &&
                    booking.Duration.End>=duration.Start &&
                    ActiveBookingStatuses.Contains(booking.Status),
                    cancellationToken);
        }

        public Task<bool> IsOverLappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
