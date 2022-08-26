using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public string BookingNo { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public int ReservationStatusId { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ReservationStatus ReservationStatus { get; set; }
        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
