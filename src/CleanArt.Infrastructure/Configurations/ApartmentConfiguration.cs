using CleanArt.Domain.Apartments;
using CleanArt.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Infrastructure.Configurations
{
    internal class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("apartments");

            builder.HasKey(apartment=>apartment.Id);

            builder.OwnsOne(ap=>ap.Address);

            //yani name onun için Name classından gelen value domainden db'ye
            //Db den çekerkende gelen değeri aslında alıp new Name nesnesi oluştur
            builder.Property(ap=>ap.Name)
                .HasMaxLength(255)
                .HasConversion(name=>name.Value,value=> new Name(value));

            builder.Property(ap => ap.Description)
                .HasMaxLength(2550)
                .HasConversion(x => x.Value, y => new Description(y));

            builder.OwnsOne(ap => ap.Price, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(ap => ap.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.Property<uint>("Version").IsRowVersion();
        }
    }
}
