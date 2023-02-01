using MassTransit;
using SharedModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly IBus _busService;
        public CustomerProductController(IBus busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public async Task<string> CreateProduct(CustomerProduct product)
        {
            if (product != null)
            {
                product.AddOnDate = DateTime.Now;
                Uri uri = new Uri("rabbit://localhost/productQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(product);
                return "true";
            }
            return "false";
        }
    }
}
