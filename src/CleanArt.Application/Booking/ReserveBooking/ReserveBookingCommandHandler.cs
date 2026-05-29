using CleanArt.Application.Abstractions.Messaging.Command;
using CleanArt.Application.Exceptions;
using CleanArt.Domain.Abstractions;
using CleanArt.Domain.Apartments;
using CleanArt.Domain.Bookings;
using CleanArt.Domain.Bookings.Exceptions;
using CleanArt.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Booking.ReserveBooking
{
    public sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingService _pricingService;

        public ReserveBookingCommandHandler(IUserRepository userRepository,
            IApartmentRepository apartmentRepository,
            IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork,
            PricingService pricingService)
        {
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
        }

        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                return Result.Failure<Guid>(new Error("2929", "Yok Kardeş Öyle Biri"));
            }

            var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);

            if (apartment is null)
            {
                return Result.Failure<Guid>(new Error("2929", "Yok Kardeş Öyle Biri"));
            }

            var duration = DateRange.Create(request.StartDate, request.EndDate);

            if (await _bookingRepository.IsOverLappingAsync(apartment, duration, cancellationToken))
            {
                return Result.Failure<Guid>(new Error("2222", "Doluuu"));
            }

            try
            {
                var booking = Domain.Bookings.Booking.Reserve(
              apartment,
              user.Id,
              duration,
              _pricingService);

                _bookingRepository.Add(booking);
                await _unitOfWork.SaveChangesAsync();
                return booking.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
                throw;
            }

          
        }
    }
}
