using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.service.Data;
using ProductAPI.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // [Route"{id}"]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {

            return _context.Products1;
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product>> GetById(int productId)
        {
            var product = await _context.Products1.FindAsync(productId);
            return product;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _context.Products1.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            _context.Products1.Update(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete(int productId)
        {
            var product = await _context.Products1.FindAsync(productId);
            _context.Products1.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("data deleted");
        }
    }
}
