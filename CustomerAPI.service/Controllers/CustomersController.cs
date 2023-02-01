using CustomerAPI.service.Data;
using CustomerAPI.service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomersController(CustomerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // [Route"{id}"]
        public ActionResult<IEnumerable<Customer>> GetProduct()
        {

            return _context.Customers1;
        }

        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<Customer>> GetById(int customerId)
        {
            var customer = await _context.Customers1.FindAsync(customerId);
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await _context.Customers1.AddAsync(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            _context.Customers1.Update(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{customerId:int}")]
        public async Task<ActionResult> Delete(int customerId)
        {
            var customer = await _context.Customers1.FindAsync(customerId);
            _context.Customers1.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok("data deleted");
        }
    }
}
