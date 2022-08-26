﻿using NewtryxWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.ViewModel
{
    public class OrderVm
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public decimal FinalTotal { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string OrderDate { get; set; }
        public IEnumerable<OrderDetailVm> OrderDetails { get; set; }
    }
}
