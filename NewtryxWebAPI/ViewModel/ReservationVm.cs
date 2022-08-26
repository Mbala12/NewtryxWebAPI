using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.ViewModel
{
    public class ReservationVm
    {
        public int ReservationId { get; set; }
        public string BookingNo { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public int ReservationStatusId { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Description { get; set; }
    }
}
