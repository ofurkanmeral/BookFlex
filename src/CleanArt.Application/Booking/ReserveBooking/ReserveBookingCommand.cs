using CleanArt.Application.Abstractions.Messaging.Command;

namespace CleanArt.Application.Booking.ReserveBooking
{
    public record ReserveBookingCommand(
        Guid ApartmentId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate) : ICommand<Guid>;
}
