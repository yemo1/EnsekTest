using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ensek.Core.Entities
{
    public class Account
    {
        
        public int AccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public ICollection<MeterReading> MeterReadings {get; set;}
    }
}