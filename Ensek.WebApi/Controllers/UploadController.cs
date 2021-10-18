using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ensek.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.Api.Controllers
{
    [ApiController]
    [Route("upload")]
    public class UploadController: ControllerBase
    {
        private readonly IReadMeterRepository _meterRepo;

        public UploadController(IReadMeterRepository meterRepo)
        {
            _meterRepo = meterRepo;
        }

        [HttpPost("readings")]
        public async Task<IActionResult> UploadMeterReadingAsync([FromBody] string filePath)
        {
            var readings = await _meterRepo.ReadMeterAsync(filePath);
            return Ok(readings);
        }
    }
}