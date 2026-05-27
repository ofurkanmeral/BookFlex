using CleanArt.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Bookings.Exceptions
{
    public static class BookingErrors
    {
        public static Error NotFound = new Error(
            "Booking.Found",
            "The booking with the specified identifier was not found");

        public static Error Overlap = new Error(
            "Booking.Overlap",
            "The current booking is overlapping with an existing one");

        public static Error NotReserved = new Error(
            "Booking.NotReserved",
            "The booking is not pending");

        public static Error NotConfirmed = new Error(
            "Booking.NotReserved",
            "The booking is not confirmed");

        public static Error AlreadyStarted = new Error(
            "Booking.AlreadyStarted",
            "The booking has already started");
    }
}
