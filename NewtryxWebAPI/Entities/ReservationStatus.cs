using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Entities
{
    public class ReservationStatus
    {
        [Key]
        public int ReservationStatusId { get; set; }
        public string ReservationStatusType { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
