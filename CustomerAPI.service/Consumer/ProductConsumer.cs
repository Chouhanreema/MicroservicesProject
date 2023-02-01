using MassTransit;
using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.service.Consumer
{
    public class ProductConsumer:IConsumer<CustomerProduct>
    {
        public async Task Consume(ConsumeContext<CustomerProduct> context)
        {
            await Task.Run(() => { var obj = context.Message; });
        }
    }
}
