using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ensek.Core.Entities;
using Ensek.Infrastructure.Data.CsvSerializer;
using Microsoft.Extensions.Logging;

namespace Ensek.Infrastructure.Data
{
    public class EnergyContextSeed
    {
        public static async Task SeedAsync(EnergyContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Accounts.Any())
                {
                    var accountData = File.ReadAllLines("../Ensek.Infrastructure/Data/SeedData/Test_Accounts.csv")
                        .Skip(1)
                        .Select(v => AccountValues.FromCsv(v))
                        .ToList();
                    foreach(var account in accountData)
                    {
                        context.Accounts.Add(account);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EnergyContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}