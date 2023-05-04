﻿using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            //TypeComplexe
            builder.OwnsOne(p=>p.FullName,full=>
            { 
                full.Property(f => f.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                full.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();

            });
            //TPH: une seule table changer le nom
            //builder.HasDiscriminator<int>("IsPassenger")
            //    .HasValue<Passenger>(0)
            //    .HasValue<Traveller>(1)
            //    .HasValue<Staff>(2);

            builder.HasDiscriminator<String>("IsTraveller")
                .HasValue<Passenger>("0")
                .HasValue<Traveller>("1")
                .HasValue<Staff>("2");
        }
    }
}
