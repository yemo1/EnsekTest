using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ensek.Core.Custom;

namespace Ensek.Core.Interfaces
{
    public interface IReadMeterRepository
    {
        Task<MeterResponse> ReadMeterAsync(string filePath);
    }
}