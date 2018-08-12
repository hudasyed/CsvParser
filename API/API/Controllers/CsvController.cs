using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Csv")]
    public class CsvController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ParseCsv()
        {
            await Task.Delay(10);
            return Ok();
        }
    }
}