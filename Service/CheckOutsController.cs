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
    public class CheckOutsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CheckOutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CheckOuts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckOut>>> GetCheckOuts()
        {
            return await _context.CheckOuts.ToListAsync();
        }

        // GET: api/CheckOuts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckOut>> GetCheckOut(Guid id)
        {
            var checkOut = await _context.CheckOuts.FindAsync(id);

            if (checkOut == null)
            {
                return NotFound();
            }

            return checkOut;
        }

        // PUT: api/CheckOuts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckOut(Guid id, CheckOut checkOut)
        {
            if (id != checkOut.CheckOutId)
            {
                return BadRequest();
            }

            _context.Entry(checkOut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckOutExists(id))
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

        // POST: api/CheckOuts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CheckOut>> PostCheckOut(CheckOut checkOut)
        {
            _context.CheckOuts.Add(checkOut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckOut", new { id = checkOut.CheckOutId }, checkOut);
        }

        // DELETE: api/CheckOuts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckOut(Guid id)
        {
            var checkOut = await _context.CheckOuts.FindAsync(id);
            if (checkOut == null)
            {
                return NotFound();
            }

            _context.CheckOuts.Remove(checkOut);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckOutExists(Guid id)
        {
            return _context.CheckOuts.Any(e => e.CheckOutId == id);
        }
    }
}
