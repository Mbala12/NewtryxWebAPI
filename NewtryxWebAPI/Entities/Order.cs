using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public decimal FinalTotal { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string OrderDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
