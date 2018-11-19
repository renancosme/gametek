using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Redbet.Domain.Models.Customers;
using Redbet.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Redbet.Infra.Data.Context
{
    public class CustomersContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
