using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Csv")]
    public class CsvController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ParseCsv([FromBody] List<CsvModel> file)
        {
            await Task.Delay(10);
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(file.Count);
        }
    }
}