using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCake.Data;
using MCake.Models;

namespace MCake.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pay>>> GetPayment()
        {
            return await _context.Payment.ToListAsync();
        }

        // GET: api/Pays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pay>> GetPay(Guid id)
        {
            var pay = await _context.Payment.FindAsync(id);

            if (pay == null)
            {
                return NotFound();
            }

            return pay;
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPay(Guid id, Pay pay)
        {
            if (id != pay.PayId)
            {
                return BadRequest();
            }

            _context.Entry(pay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pay>> PostPay(Pay pay)
        {
            _context.Payment.Add(pay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPay", new { id = pay.PayId }, pay);
        }

        // DELETE: api/Pays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePay(Guid id)
        {
            var pay = await _context.Payment.FindAsync(id);
            if (pay == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(pay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayExists(Guid id)
        {
            return _context.Payment.Any(e => e.PayId == id);
        }
    }
}
