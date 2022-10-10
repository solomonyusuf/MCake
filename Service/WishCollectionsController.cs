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
    public class WishCollectionsController : ControllerBase
    {
        private readonly CartDbContext _context;

        public WishCollectionsController(CartDbContext context)
        {
            _context = context;
        }

        // GET: api/WishCollections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishCollection>>> GetWishCollections()
        {
            return await _context.WishCollections.ToListAsync();
        }

        // GET: api/WishCollections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WishCollection>> GetWishCollection(Guid id)
        {
            var wishCollection = await _context.WishCollections.FindAsync(id);

            if (wishCollection == null)
            {
                return NotFound();
            }

            return wishCollection;
        }

        // PUT: api/WishCollections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishCollection(Guid id, WishCollection wishCollection)
        {
            if (id != wishCollection.WishCollectionId)
            {
                return BadRequest();
            }

            _context.Entry(wishCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishCollectionExists(id))
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

        // POST: api/WishCollections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WishCollection>> PostWishCollection(WishCollection wishCollection)
        {
            _context.WishCollections.Add(wishCollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishCollection", new { id = wishCollection.WishCollectionId }, wishCollection);
        }

        // DELETE: api/WishCollections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishCollection(Guid id)
        {
            var wishCollection = await _context.WishCollections.FindAsync(id);
            if (wishCollection == null)
            {
                return NotFound();
            }

            _context.WishCollections.Remove(wishCollection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WishCollectionExists(Guid id)
        {
            return _context.WishCollections.Any(e => e.WishCollectionId == id);
        }
    }
}
