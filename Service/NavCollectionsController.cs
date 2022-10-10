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
    public class NavCollectionsController : ControllerBase
    {
        private readonly NavCollectionDbContext _context;

        public NavCollectionsController(NavCollectionDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductCollections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCollection>>> GetProductCollections()
        {
            return await _context.ProductCollections.ToListAsync();
        }

        // GET: api/ProductCollections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCollection>> GetProductCollection(Guid id)
        {
            var productCollection = await _context.ProductCollections.FindAsync(id);

            if (productCollection == null)
            {
                return NotFound();
            }

            return productCollection;
        }

        // PUT: api/ProductCollections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCollection(Guid id, ProductCollection productCollection)
        {
            if (id != productCollection.ProductCollectionId)
            {
                return BadRequest();
            }

            _context.Entry(productCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCollectionExists(id))
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

        // POST: api/ProductCollections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCollection>> PostProductCollection(ProductCollection productCollection)
        {
            _context.ProductCollections.Add(productCollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCollection", new { id = productCollection.ProductCollectionId }, productCollection);
        }

        // DELETE: api/ProductCollections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCollection(Guid id)
        {
            var productCollection = await _context.ProductCollections.FindAsync(id);
            if (productCollection == null)
            {
                return NotFound();
            }

            _context.ProductCollections.Remove(productCollection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCollectionExists(Guid id)
        {
            return _context.ProductCollections.Any(e => e.ProductCollectionId == id);
        }
    }
}
