using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ensek.Core.Entities;

namespace Ensek.Infrastructure.Data.CsvSerializer
{
    public class AccountValues
    {
        public static Account FromCsv(string line)
        {
            string[] values = line.Split(',');
            Account account = new Account();
            account.AccountId = Int32.Parse(values[0]);
            account.FirstName = values[1];
            account.LastName = values[2];
            return account;
        }
    }
}