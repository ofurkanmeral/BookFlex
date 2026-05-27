using CleanArt.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Bookings.Events
{
    public sealed record BookingConfirmedDomainEvent(Guid Id):IDomaintEvent;
   
}
