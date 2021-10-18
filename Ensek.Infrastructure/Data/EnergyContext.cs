using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Ensek.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Infrastructure.Data
{
    public class EnergyContext: DbContext
    {
        public EnergyContext(DbContextOptions<EnergyContext> options): base(options)
        {
            
        }
        public DbSet<Account> Accounts {get; set;}
        public DbSet<MeterReading> MeterReadings {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}