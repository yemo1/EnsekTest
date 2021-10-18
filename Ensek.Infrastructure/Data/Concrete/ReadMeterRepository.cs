using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ensek.Core.Custom;
using Ensek.Core.Entities;
using Ensek.Core.Interfaces;
using Ensek.Infrastructure.Data.CsvSerializer;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Infrastructure.Data.Concrete
{
    public class ReadMeterRepository: IReadMeterRepository
    {
        private readonly EnergyContext _context;

        public ReadMeterRepository(EnergyContext context)
        {
            _context = context;
        }

        public async Task<MeterResponse> ReadMeterAsync(string filePath)
        {
            var account = await _context.Accounts.ToListAsync();
            MeterReading meter = new MeterReading();
            List<string> readingList = new List<string>();
            string lines;
            int failed = 0;
            int succeded = 0;
            int number;
            
            using(StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                lines = reader.ReadLine();
                
                while(lines != null)
                {
                    readingList.Add(lines);
                    var exists = readingList.Any(x=>x.Contains(lines));
                    if(!exists)
                    {
                        string[] values = lines.Split(',');
                        bool valid = Int32.TryParse(values[2],out number);
                        int accountId = Int32.Parse(values[0]);
                        int readingValue = Int32.Parse(values[2]);
                        
                        if(account.Any(x=>x.AccountId == accountId) && valid && !exists)
                        {
                            lines = reader.ReadLine();
                            meter.AccountId = accountId;
                            meter.MeterReadingDateTime = DateTime.Parse(values[1]);
                            meter.MeterReadValue = readingValue; 
                            succeded += 1;
                        }
                        else
                        {
                            failed += 1;
                        }
                    }
                }            
            }

            var response = new MeterResponse()
            {
                Failed = failed,
                Succeded = succeded
            };

            return response;
        }
    }
}