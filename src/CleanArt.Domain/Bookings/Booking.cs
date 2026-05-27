using CleanArt.Domain.Abstractions;
using CleanArt.Domain.Apartments;
using CleanArt.Domain.Bookings.Events;
using CleanArt.Domain.Bookings.Exceptions;
using CleanArt.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region anomolik model
/*
 
        public Guid ApartmentId { get;private set; }
        public Guid UserId { get; private set; }
        public DateRange Duration { get; private set; }
        public Money PriceForPeriod { get; private set; }
        public Money CleaningFee { get; private set; }
        public Money AmenitiesUpCharge { get; private set; }
        public Money TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }   
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ConfirmedOnUtc { get; private set; }
        public DateTime? RejectedOnUtc { get; private set; }
        public DateTime? CompletedOnUtc { get; private set; }
        public DateTime? CancelledOnUtc { get;private set; }
 
 */
#endregion

namespace CleanArt.Domain.Bookings
{
    /// <summary>
    /// Rezervasyonu temsil eden entity
    /// </summary>
    public sealed class Booking : Entity
    {
        private Booking(Guid id, 
            Guid apartmentId, 
            Guid userId, 
            DateRange duration,
            Money priceForPeriod,
            Money amenitiesUpCharge,
            Money totalPrice,
            BookingStatus status,
            Money cleaningfee) 
            : base(id)
        {
            ApartmentId = apartmentId;
            UserId = userId;
            Duration = duration;
            PriceForPeriod = priceForPeriod;
            AmenitiesUpCharge = amenitiesUpCharge;
            TotalPrice = totalPrice;
            Status = status;
            CleaningFee = cleaningfee;
        }

        public Guid ApartmentId { get;private set; }
        public Guid UserId { get; private set; }
        public DateRange Duration { get; private set; }
        public Money PriceForPeriod { get; private set; }
        public Money CleaningFee { get; private set; }
        public Money AmenitiesUpCharge { get; private set; }
        public Money TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }   
        public DateTime ReservedOnUtc { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ConfirmedOnUtc { get; private set; }
        public DateTime? RejectedOnUtc { get; private set; }
        public DateTime? CompletedOnUtc { get; private set; }
        public DateTime? CancelledOnUtc { get;private set; }


       public static Booking Reserve(
           Apartment apartment,
           Guid userId,
           DateRange duration,
           PricingService pricingService)
        {
            var pricingDetails=pricingService.CalculatePrice(apartment,duration);

            var booking = new Booking(
                Guid.NewGuid(),
                apartment.Id,
                userId,
                duration,
                pricingDetails.PricingForPeriod,
                pricingDetails.AmenitiesUpCharge,
                pricingDetails.TotalPrice,
                BookingStatus.Reserved,
                pricingDetails.CleaningFee
                );

            booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

            apartment.LastBookedOnUtc=DateTime.UtcNow;

            return booking; 
        }


        public Result Confirm(DateTime utcNow)
        {
            if(Status != BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }
            Status=BookingStatus.Confirmed;
            ConfirmedOnUtc = utcNow;
            RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));
            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if(Status !=BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }
            Status=BookingStatus.Rejected;
            RejectedOnUtc = utcNow;
            RaiseDomainEvent(new BookingRejectedDomainEvent(Id));
            return Result.Failure(Error.None);
        }
    }
}
