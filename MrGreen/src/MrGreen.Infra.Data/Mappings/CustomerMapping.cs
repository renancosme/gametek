﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MrGreen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrGreen.Infra.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(c => c.FirstName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(c => c.Address)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(c => c.PersonalNumber)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder
                .Ignore(e => e.ValidationResult);
            
            builder
                .Ignore(e => e.CascadeMode);

            builder
                .ToTable("Customer");
        }
    }
}
