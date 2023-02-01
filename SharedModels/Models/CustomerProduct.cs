﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels.Models
{
    public class CustomerProduct
    {
        public string ProductName { get; set; }

        public DateTime AddOnDate { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }
    }
}
