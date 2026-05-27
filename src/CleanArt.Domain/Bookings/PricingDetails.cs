using CleanArt.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Bookings
{
    public record PricingDetails(
        Money PricingForPeriod,
        Money CleaningFee,
        Money AmenitiesUpCharge,
        Money TotalPrice);
}
