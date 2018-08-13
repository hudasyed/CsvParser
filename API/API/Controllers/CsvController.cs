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
        private readonly Context _context;

        public CsvController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// This method is reponsible for ingesting a CSV file with a parent, child, quantity model
        /// and adding or updating that information to a database.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Bad Request: If model error
        /// Internal Server Error: Database error
        /// Ok: Data correctly added to database</returns>
        [HttpPost]
        public async Task<IActionResult> ParseCsv([FromBody] List<Record> file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        foreach (var item in file)
                        {
                            await AddOrUpdate(item);                            
                        }
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return Ok();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return StatusCode(500);
                    }
                }
            }
        }

        private async Task AddOrUpdate(Record r)
        {
            var record = await _context.Records.FindAsync(r.Parent, r.Child);
            if(record == null) // Add
            {
                await _context.Records.AddAsync(r);
            }
            else // Update
            {
                record.Quantity = r.Quantity;
                _context.Entry(record).Property("Quantity").IsModified = true;
            }

        }
    }
}