using CleanArt.Domain.Abstractions;
using CleanArt.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

#region İlk domain ve Rich domain bu hale geldi gibi bunu incele muhakkkak

/*
     public sealed class Apartment:Entity
    {
        public Apartment(Guid id):base(id) { }
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Country { get; private set; }
        public string State { get;private set; }
        public string ZipCode { get; private set; }
        public string City {  get; private set; }
        public string Street { get; private set; }
        public decimal PriceAmount {  get; private set; }
        public string PriceCurrency {  get; private set; }
        public decimal CleaningFeeAmount { get; private set; }
        public string CleaningFeeCurrency { get; private set; }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<Amenity> Amenities { get; private set; } = new();
    }
 */

#endregion


namespace CleanArt.Domain.Apartments
{
    public sealed class Apartment:Entity
    {
        public Apartment(
            Guid id,
            Name name,
            Description description,
            Address address,
            Money price,
            Money cleaningFee,
            List<Amenity>amenities)
            :base(id) 
        {
            Name = name;
            Description = description;
            Address = address;
            Price = price;
            CleaningFee=cleaningFee;
            Amenities = amenities;
        }
        
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; private set; }
        public Money CleaningFee { get;private set; }
        public DateTime? LastBookedOnUtc { get; internal set; }
        public List<Amenity> Amenities { get; private set; } = new();
    }
}
