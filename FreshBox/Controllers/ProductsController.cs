using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreshBox.Data;
using FreshBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Farmer)
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Farmer)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(new { message = "Product ID mismatch" });
            }

            // Set updated timestamp
            product.UpdatedAt = DateTime.UtcNow;
            
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound(new { message = "Product not found" });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Set timestamps
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Products/category/{categoryId}
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .Include(p => p.Farmer)
                .ToListAsync();

            return products;
        }

        // GET: api/Products/search?query={query}
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetProducts();
            }

            var products = await _context.Products
                .Where(p => p.Name.Contains(query) || p.Description.Contains(query))
                .Include(p => p.Category)
                .Include(p => p.Farmer)
                .ToListAsync();

            return products;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}